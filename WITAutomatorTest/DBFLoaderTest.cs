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
    }
}
