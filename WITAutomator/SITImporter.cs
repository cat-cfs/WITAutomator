using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBMSIT.DBImport;
using CBMSIT.UserData;
using CBMSIT.Controllers;
namespace WITAutomator
{
    class SITImporter
    {

        public void Import(string sit_db_path) {
            
            CBMDBObject db = new CBMDBObject(sit_db_path);
            DBImporter importer = new DBImporter(db,
                AgeClassTableName: "SIT_AgeClasses",
                ClassifiersTableName: "SIT_Classifiers",
                DisturbanceEventsTableName: "SIT_Events",
                DisturbanceTypesTableName: "SIT_DisturbanceTypes",
                EligibilityTableName: null,
                InventoryTableName: "SIT_Inventory",
                TransitionRulesTableName: "SIT_Transitions",
                YieldTableName: "SIT_Yields",
                AddMissingClassifierValues: false);
            importer.Import();
            UserDataSet ds = new UserDataSet();
            ds.AgeClasses = importer.AgeClasses;
            ds.Classifiers = importer.Classifiers;
            ds.DisturbanceEvents = importer.DisturbanceEvents;
            ds.DisturbanceTypes = importer.DisturbanceTypes;
            ds.Inventories = importer.Inventories;
            ds.TransitionRules = importer.TransitionRules;
            ds.Yields = importer.Yields;

            CBMSIT.ProjectCreation.CBMProjectWriter wr = new CBMSIT.ProjectCreation.CBMProjectWriter(ds,)
        }
    }
}
