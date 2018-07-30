using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Data;
namespace WITAutomator
{
    public class DBFLoader
    {
        static string GetBlankDBPath()
        {
            string local_dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return Path.Combine(local_dir, "blank.accdb");
        }

        static DataTable ReadDBF(string dbfpath)
        {
            string dirname = Path.GetDirectoryName(dbfpath);
            string filename = Path.GetFileName(dbfpath);
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                                        String.Format("Data Source={0}", dirname) +
                                        "Extended Properties=dBase III")) {
                OleDbCommand cmd = new OleDbCommand(String.Format("SELECT * FROM [{0}]", filename));
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        static Dictionary<string, DataTable> ReadWoodStockDBFs(string dbf_dir)
        {
            //the standard woodstock table names/file names 
            var woodstock_names = new Dictionary<string, string>()
            {
                { "Actions", "actions.dbf" },
                { "Areas", "areas.dbf" },
                { "Yeilds", "yields.dbf" },
                { "Themes", "themes.dbf" },
                { "Transitions", "trans.dbf" },
                { "Schedule", "schedule.dbf" },
            };

            var output = new Dictionary<string, DataTable>();
            foreach(var item in woodstock_names)
            {
                string path = Path.Combine("", )
                output[item.Key] = ReadDBF(item.Value);
            }
            return output;
        }
        /// <summary>
        /// loads the standard woodstock dbf files into an accdb format access database at the specified output path
        /// </summary>
        /// <param name="dbf_dir"></param>
        /// <param name="db_output_path"></param>
        /// <returns></returns>
        static void LoadDBFFiles(string dbf_dir, string db_output_path)
        {
            File.Copy(GetBlankDBPath(), db_output_path);
            string connection_string = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + db_output_path + ";";
            using (OleDbConnection con = new OleDbConnection(connection_string))
            {
                Dictionary<string, DataTable> woodstock_dbfs = ReadWoodStockDBFs(dbf_dir);

            }
            

        }
    }
}
