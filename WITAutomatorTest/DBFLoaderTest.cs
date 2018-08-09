using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WITAutomator;
using System.IO;
namespace WITAutomatorTest
{
    [TestClass]
    public class DBFLoaderTest
    {
        string test_db_output = "test_output.accdb";
        [TestMethod]
        public void TestBlankDBPath()
        {
            string blank_db_path = DBFLoader.GetBlankDBPath();
            Assert.IsTrue(System.IO.File.Exists(blank_db_path));
        }

        [TestCleanup]
        public void TearDown()
        {
            if (File.Exists(test_db_output))
            {
                File.Delete(test_db_output);
            }
        }



        [TestMethod]
        public void TestLoadDBFFiles()
        {
            string connection_string = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + test_db_output + ";";
            int tables_loaded = DBFLoader.LoadDBFFiles(".", test_db_output, WoodstockConstants.StandardWoodTables);
            Assert.IsTrue(tables_loaded == WoodstockConstants.StandardWoodTables.Count);
            Assert.IsTrue(File.Exists(test_db_output));
        }
    }
}
