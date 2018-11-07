using Newtonsoft.Json.Linq;
using StandardImportToolPlugin;
using System.IO;
namespace WITAutomator
{
    class SITImporter
    {

        public void Import(string jsonConfigTemplatePath, string outputPath,
            string inputPath) {
            string json = "";
            using (var s = File.OpenRead(jsonConfigTemplatePath))
            using (StreamReader reader = new StreamReader(s))
            {
                json = reader.ReadToEnd();
            }
            JObject jsonObj = JObject.Parse(json);
            jsonObj["output_path"] = outputPath;
            jsonObj["import_config"]["path"] = inputPath;
            var loader = new StandardImportToolPlugin.JsonConfigLoader();
            Sitplugin sitplugin = loader.Load(jsonObj.ToString());
            sitplugin.Import();
        }
    }
}
