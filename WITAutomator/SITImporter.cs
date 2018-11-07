using log4net;
using Newtonsoft.Json.Linq;
using StandardImportToolPlugin;
using System.IO;
namespace WITAutomator
{
    public class SITImporter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SITImporter));
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
            log.Info(string.Format("running Operational-Scale CBM-CFS3" +
                " Standard import tool. input database {0}", inputPath));
            Sitplugin sitplugin = loader.Load(jsonObj.ToString());
            sitplugin.Import();
            log.Info(string.Format("finished standard import tool. CBM" +
                " project db: {0}", outputPath));
        }
    }
}
