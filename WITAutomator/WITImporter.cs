using log4net;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WoodStockImportTool;
namespace WITAutomator
{
    public class WITImporter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WITImporter));
        /// <summary>
        /// import the woodstock dataset
        /// </summary>
        /// <param name="inputPath">path to access database containing the woodstock dbf data. 
        /// The SIT input tables will be created in this database</param>
        /// <param name="inputTables">list names of the tables to import</param>
        /// <param name="roundingOption"></param>
        public bool Import(string inputPath, List<WoodStockTable> inputTables, string species_theme_name,
            WoodStock.RoundingOption roundingOption = WoodStock.RoundingOption.MidPointRoundedUp)
        {
            WoodStock ws = new WoodStock();

            //assign the mandatory event handlers
            ws.taskMessage += new TaskMessage((a)=>{ });
            ws.message += new Message((a) => { });
            ws.setProgress += new SetProgress((a) => { });
            ws.pauseAndPrompt += new PauseAndPrompt((a) => { });
            ws.tableChanged += new TableChanged((a) => { });

            ws.outputPath = @"C:\dev\WITAutomator\imported.accdb";
            ArrayList _inputTables = new ArrayList(inputTables.Select(a=>a.Name).ToList());
            log.Info("running Operational-Scale CBM-CFS3 Woodstock import tool.");
            bool result = ws.startImport(inputPath, roundingOption, _inputTables, false, species_theme_name);
            log.Info(string.Format("finished running Woodstock import tool. Results stored in database {0}",
                inputPath));
            return result;
        }
    }
}
