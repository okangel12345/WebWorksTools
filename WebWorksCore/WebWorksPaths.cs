using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWorksShared
{
    public class WebWorksPaths
    {
        //------------------------------------------------------------------------------------------
        // WebWorks Misc Paths
        //------------------------------------------------------------------------------------------
        public static readonly string MiscFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebWorksMisc");

        //------------------------------------------------------------------------------------------
        // Model Tools
        //------------------------------------------------------------------------------------------
        public static readonly string Tool_RemoveHairStrands = Path.Combine(MiscFolder, "remove_HairStrands.exe");

        // Paths to Spider-Man 2 model tools
        public static readonly string SpiderMan2_ModelExtractToolPath = Path.Combine(MiscFolder, "sm2_extract.exe");
        public static readonly string SpiderMan2_ModelImportToolPath = Path.Combine(MiscFolder, "sm2_import.exe");

        // Spider-Man 2's "spider.ini" path
        // Note: This is exclusive of the tool developed by id-daemon for i30 (Unofficial port of MSM2)
        public static readonly string Spiderman2_ModelExtractIniPath = Path.Combine(MiscFolder, "spider.ini");

        // Paths to ALERT's model tools
        public static readonly string ALERT_ModelExtractToolPath = Path.Combine(MiscFolder, "ALERT_extract.exe");
        public static readonly string ALERT_TemporaryModelPath = Path.Combine(MiscFolder, "tempfile_model.model");
        public static readonly string ALERT_ModelImportToolPath = Path.Combine(MiscFolder, "ALERT_import.exe");

        //------------------------------------------------------------------------------------------
        // Config Tools
        //------------------------------------------------------------------------------------------
        public static readonly string ALERT_JSONToConfig = Path.Combine(MiscFolder, "ALERT_jsontoconfig.exe");
        public static readonly string ALERT_ConfigToJSON = Path.Combine(MiscFolder, "ALERT_configtojson.exe");
    }
}
