using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AKwin32.util
{
    public class Configuration
    {

        public const String CompanyName = "BluegleTek Soft";
        public const String ApplicationName = "AnimeKakkoi";

        /// <summary>
        /// 
        /// </summary>
        internal static String ApplicationDataFolder
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                return String.Format("{1}{0}{2}{0}{3}{0}", System.IO.Path.DirectorySeparatorChar, path, CompanyName, ApplicationName);
            }
        }


        /// <summary>
        /// ?
        /// </summary>
        internal const String AppConfiguration = "";

        [Obsolete]
        internal const String UserInformationPath = "UserInformation.ak";

        internal static string GetSetting(string key)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = ApplicationDataFolder + AppConfiguration;

            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value;
        }
    }
}
