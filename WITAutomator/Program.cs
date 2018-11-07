using CommandLine;
using log4net;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using log4net.Config;

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
            XmlConfigurator.Configure();
            log.Info("Startup");
            var options = new Options();
            var result = Parser.Default.ParseArguments<Options>(args);
            result.WithParsed(Run);
            log.Info("Finished");
        }
        private static void Run(Options options)
        {
            try
            {
                JObject configObject = JObject.Parse(File.ReadAllText(
                    options.ConfigurationPath));
                string getValue(string key) => (string)configObject[key];

                if (!Enum.TryParse(getValue("rounding_option"),
                    out WoodStockImportTool.WoodStock.RoundingOption roundingOption))
                {
                    throw new ArgumentException(
                        String.Format(
                            "specified string {0} not convertable to" +
                            " woodstock rounding option",
                            getValue("rounding_option")));
                }
                log.Info("Running with options:" +Environment.NewLine + configObject.ToString(Newtonsoft.Json.Formatting.Indented));
                
                Run(options.SITConfigTemplatePath,
                    getValue("dbf_dir"),
                    getValue("cbm_project_output_path"),
                    getValue("woodstock_accdb_path"),
                    roundingOption,
                    getValue("species_theme_name"));
            }
            catch (Exception ex)
            {
                log.Error("application exception", ex);
            }
        }
        private static void Run(string sitJsonConfigTemplatePath,
            string dbf_dir, string cbm_project_output_path,
            string woodstock_accdb_path,
            WoodStockImportTool.WoodStock.RoundingOption roundingOption,
            string species_theme_name)
        {
            
            var woodstock_tables = WoodstockConstants.StandardWoodTables;
            DBFLoader.LoadDBFFiles(dbf_dir, woodstock_accdb_path,
                woodstock_tables);
            WITImporter importer = new WITImporter();
            importer.Import(woodstock_accdb_path, woodstock_tables,
                species_theme_name, roundingOption);
            SITImporter sit_importer = new SITImporter();
            string cbmProjectPath = cbm_project_output_path;
            sit_importer.Import(sitJsonConfigTemplatePath,
                cbmProjectPath, woodstock_accdb_path);
        }
    }
}
