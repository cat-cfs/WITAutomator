using System.Collections.Generic;

namespace WITAutomator
{
    public static class WoodstockConstants
    {

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
