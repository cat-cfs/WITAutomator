using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WITAutomator
{
    public static class WoodstockConstants
    {
        public struct WoodStockTable
        {
            public WoodStockTable(string name, string filename)
            {
                Name = name;
                FileName = filename;
            }
            public string Name { get; set; }
            public string FileName { get; set; }
            public bool FileExists(string dbf_dir)
            {
                string fullPath = Path.Combine(dbf_dir, FileName);
                if (!File.Exists(fullPath))
                {
                    return false;
                }
                return true;
            }
        }
        public static List<WoodStockTable> StandardWoodTables
            = new List<WoodStockTable>{
            new WoodStockTable("Actions", "actions.dbf"),
            new WoodStockTable("Areas", "areas.dbf"),
            new WoodStockTable("Yeilds", "yields.dbf"),
            new WoodStockTable("Themes", "themes.dbf"),
            new WoodStockTable("Transitions", "trans.dbf"),
            new WoodStockTable("Schedule", "schedule.dbf")
         };
    }
}
