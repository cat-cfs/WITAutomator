using System.Collections;
using System.Collections.Generic;
using WoodStockImportTool;

namespace WITAutomator
{
    class WITImporter
    {
        /// <summary>
        /// import the woodstock dataset
        /// </summary>
        /// <param name="inputPath">path to access database containing the woodstock dbf data. 
        /// The SIT input tables will be created in this database</param>
        /// <param name="inputTables">list names of the tables to import</param>
        /// <param name="roundingOption"></param>
        public void Import(string inputPath, List<string> inputTables,
            WoodStock.RoundingOption roundingOption = WoodStock.RoundingOption.MidPointRoundedUp)
        {
            WoodStock ws = new WoodStock();
            ArrayList _inputTables = new ArrayList(inputTables);
            ws.startImport(inputPath, roundingOption, _inputTables, false);
        }
    }
}
