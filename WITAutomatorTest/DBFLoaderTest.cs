using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITAutomator;

namespace WITAutomatorTest
{
    [TestClass]
    public class DBFLoaderTest
    {
        [TestMethod]
        public void TestBlankDBPath()
        {
            string blank_db_path = DBFLoader.GetBlankDBPath();
            Assert.IsTrue(System.IO.File.Exists(blank_db_path));
        }

        [TestMethod]
        public void TestReadDBF()
        {
            List<string> expected_columns = new List<string> {
                "THEME1", "THEME2", "THEME3", "THEME4", "THEME5",
                "THEME6", "THEME7", "THEME8", "THEME9", "THEME10",
                "AGECLASS", "AREA", "PERIOD" };

            System.Data.DataTable dt = DBFLoader.ReadDBF("areas.dbf");
            var dbfColumnNames = (from a in Enumerable.Range(0, dt.Columns.Count)
                                  select dt.Columns[a].ColumnName).ToList();
            Assert.IsTrue(expected_columns.SequenceEqual(dbfColumnNames));

        }

        [TestMethod]
        public void TestReadWoodStockDBFs()
        {
            var result = DBFLoader.ReadWoodStockDBFs(".");

            Assert.IsTrue(result.ContainsKey("Actions"));
            Assert.IsTrue(result.ContainsKey("Areas"));
            Assert.IsTrue(result.ContainsKey("Yeilds"));
            Assert.IsTrue(result.ContainsKey("Themes"));
            Assert.IsTrue(result.ContainsKey("Transitions"));
            Assert.IsTrue(result.ContainsKey("Schedule"));



        }

        [TestMethod]
        public void TestLoadDBFFiles()
        {
            DBFLoader.LoadDBFFiles(".", "test_output.accdb");

        }
    }
}
