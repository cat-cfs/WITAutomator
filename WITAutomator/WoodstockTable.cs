using System.IO;
namespace WITAutomator
{
    public struct WoodStockTable
    {
        public WoodStockTable(string name, string filename)
        {
            Name = name;
            FileName = filename;
        }
        public string Name { get; set; }
        public string FileName { get; set; }
        public bool FileExists(string dbf_dir)
        {
            string fullPath = Path.Combine(dbf_dir, FileName);
            if (!File.Exists(fullPath))
            {
                return false;
            }
            return true;
        }
    }
}
