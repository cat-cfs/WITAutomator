using CommandLine;
using log4net;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WITAutomator
{

    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        class Options
        {
            [Option(
                shortName: 'c',
                longName: "configurationPath",
                Required = true,
                HelpText = "Path to a json format file containing WITAutomator app configuration"
                )]
            public string ConfigurationPath { get; set; }

            [Option(
                shortName: 's',
                longName: "sitConfigTemplatePath",
                Required = true,
                HelpText = "Path to a json format file containing a partial StandardImportToolPlugin configuration"
                )]
            public string SITConfigTemplatePath { get; set; }
        }
        static void Main(string[] args)
        {
            var options = new Options();
            var result = Parser.Default.ParseArguments<Options>(args);
            result.WithParsed(a => { Run(a); });
            string JsonConfigTemplatePath = @"C:\dev\WITAutomator\config_template.json";
            string dbf_dir = @"C:\dev\WITAutomator\WITAutomatorTest";
            string cbm_project_output_path = @"C:\dev\WITAutomator\cbm_project.mdb";
            string woodstock_accdb_path = @"C:\dev\WITAutomator\woodstock.accdb";
            var roundingOption = WoodStockImportTool.WoodStock.RoundingOption.MidPointRoundedDown;
            string species_theme_name = null;

            Run(JsonConfigTemplatePath, dbf_dir, cbm_project_output_path, woodstock_accdb_path, roundingOption, species_theme_name);

        }
        private static void Run(Options options)
        {

        }
        private static void Run(string sitJsonConfigTemplatePath, string dbf_dir, string cbm_project_output_path, string woodstock_accdb_path, WoodStockImportTool.WoodStock.RoundingOption roundingOption, string species_theme_name)
        {
            var woodstock_tables = WoodstockConstants.StandardWoodTables;
            DBFLoader.LoadDBFFiles(dbf_dir, woodstock_accdb_path, woodstock_tables);
            WITImporter importer = new WITImporter();
            importer.Import(woodstock_accdb_path, woodstock_tables, species_theme_name, roundingOption);
            SITImporter sit_importer = new SITImporter();
            string cbmProjectPath = cbm_project_output_path;
            sit_importer.Import(sitJsonConfigTemplatePath,
                cbmProjectPath, woodstock_accdb_path);
        }
    }
}
