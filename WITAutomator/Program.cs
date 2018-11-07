using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WITAutomator
{
    class Program
    {
        static void Main(string[] args)
        {

            string dbf_dir = @"C:\dev\WITAutomator\WITAutomatorTest";
            var woodstock_tables = WoodstockConstants.StandardWoodTables;
            string woodstock_accdb_path = @"C:\dev\WITAutomator\woodstock.accdb";
            var roundingOption = WoodStockImportTool.WoodStock.RoundingOption.MidPointRoundedDown;
            string species_theme_name = null;
           // DBFLoader.LoadDBFFiles(dbf_dir, woodstock_accdb_path, woodstock_tables);
            //WITImporter importer = new WITImporter();
            //importer.Import(woodstock_accdb_path, woodstock_tables, species_theme_name, roundingOption);

            SITImporter sit_importer = new SITImporter();
            string cbmProjectPath = @"C:\dev\WITAutomator\cbm_project.mdb";
            sit_importer.Import(@"C:\dev\WITAutomator\config_template.json",
                cbmProjectPath, woodstock_accdb_path);

        }
    }
}
