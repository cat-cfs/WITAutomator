using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
namespace WITAutomator
{
    public class DBFLoader
    {
        public static string GetBlankDBPath()
        {
            string local_dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(local_dir, "blank.accdb");
        }

        /// <summary>
        /// loads the standard woodstock dbf files into an accdb format access database at the specified output path
        /// </summary>
        /// <param name="dbf_dir">directory containing the dbf files</param>
        /// <param name="db_output_path">output path for a newly created accdb format access db with the dbf files copied into tables</param>
        /// <param name="woodstock_names">the woodstock tablename/filename pairs</param>
        /// <returns>The number of sucessfully loaded tables, or 0 if no table was loaded</returns>
        public static int LoadDBFFiles(string dbf_dir, string db_output_path, List<WoodStockTable> woodstock_names)
        {
            File.Copy(GetBlankDBPath(), db_output_path);
            int tablesLoaded = 0;
            string connection_string = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + db_output_path + ";";
            using (OleDbConnection con = new OleDbConnection(connection_string))
            {
                con.Open();
                foreach (var ws in woodstock_names) {

                    dbf_dir = Path.GetFullPath(dbf_dir);
                    if (!ws.FileExists(dbf_dir))
                    {
                        throw new ArgumentException(
                            String.Format("specified file {0} does not exist",
                                Path.Combine(dbf_dir, ws.FileName)));
                    }
                    string query = String.Format(
                        "SELECT * INTO [{0}] FROM [dBase III;DATABASE={1}].[{2}]",
                        ws.Name, dbf_dir, ws.FileName);
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    tablesLoaded++;
                }
                con.Close();
            }
            return tablesLoaded;
        }
    }
}
