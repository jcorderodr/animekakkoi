using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Framework.io
{
    public class Configuration
    {

        public const String CompanyName = "BluegleTek Soft";
        public const String ApplicationName = "AnimeKakkoi";

        private const String AppConfigFile = "Framework.config";

        internal const String RS_CENTRAL = "ak_data.bin";
        internal const String RS_QUEUE = "ak_queue.ak";
        internal const String RS_WATCHED = "ak_watched.ak";
        internal const String RS_WATCHING = "ak_watching.ak";
        internal const String RS_WANT_SEE = "ak_wantsee.ak";
        internal const String RS_TAKED_DOWM = "ak_takeddowm.ak";


        internal const String MAIN_DATA_PROPERTIES_SECTION = "Properties";
        internal const bool APP_REPO_AUTOSAVE = true;

        internal static String ApplicationDataFolder
        {
            get
            {
                //System.Windows.Forms.Application.CommonAppDataPath;
                //@"C:\Users\Anib0warE\Documents\Proyectos\AnimeKakkoi\source\Framework\Framework.config";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                return String.Format("{1}{0}{2}{0}{3}{0}", System.IO.Path.DirectorySeparatorChar, path, CompanyName, ApplicationName);
            }
        }

        internal static String AppConfiguration
        {
            get
            {
                return ApplicationDataFolder + AppConfigFile;
            }
        }

        internal static String GetSetting(string key)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = AppConfiguration;

            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value;
        }

        internal static String GetAkFile(Framework.entity.ENTITY_STATE state)
        {
            switch (state)
            {
                case entity.ENTITY_STATE.QUEUE:
                    return RS_QUEUE;
                case entity.ENTITY_STATE.WATCHING:
                    return RS_WATCHING;
                case entity.ENTITY_STATE.WATCHED:
                    return RS_WATCHED;
                case entity.ENTITY_STATE.WANT_TO:
                    return RS_WANT_SEE;
                case entity.ENTITY_STATE.TAKED_DOWN:
                    return RS_TAKED_DOWM;
                default:
                    return "";
            }
        }


    }
}
