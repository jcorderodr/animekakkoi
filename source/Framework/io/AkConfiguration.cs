using System;
using System.Configuration;
using System.IO;

namespace AnimeKakkoi.Framework.IO
{
    /// <summary>
    /// Provides access, properties and settings.
    /// </summary>
    public abstract class AkConfiguration
    {

        public const String COMPANY_NAME = "Corderoski";
        public const String APPLICATION_NAME = "AnimeKakkoi";

        private const String AppConfigFile = "Framework.config";

        internal const String RS_CENTRAL = "ak_data.bin";
        internal const String RS_QUEUE = "ak_queue.akm";
        internal const String RS_WATCHED = "ak_watched.akm";
        internal const String RS_WATCHING = "ak_watching.akm";
        internal const String RS_WANT_SEE = "ak_wantsee.akm";
        internal const String RS_TAKED_DOWM = "ak_takeddowm.akm";


        internal const String PROPERTIES_SECTION_MAIN_DATA = "Properties";
        internal const bool APP_REPO_AUTOSAVE = true;

        public static String ApplicationDataFolder
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return String.Format("{1}{0}{2}{0}{3}{0}", Path.DirectorySeparatorChar, path, COMPANY_NAME, APPLICATION_NAME);
            }
        }

        internal static String AppConfiguration
        {
            get
            {
                return ApplicationDataFolder + AppConfigFile;
            }
        }

        #region Functions

        public static String GetSetting(string key)
        {
            var configMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppConfiguration
                };

            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value;
        }

        internal static String GetAkFile(Entities.EntityState state)
        {
            switch (state)
            {
                case Entities.EntityState.Queue:
                    return RS_QUEUE;
                case Entities.EntityState.Watching:
                    return RS_WATCHING;
                case Entities.EntityState.Watched:
                    return RS_WATCHED;
                case Entities.EntityState.WantTo:
                    return RS_WANT_SEE;
                case Entities.EntityState.TakedDown:
                    return RS_TAKED_DOWM;
                default:
                    return "";
            }
        }

        internal static String[] GetBackUpFiles()
        {
            return new string[] 
            {
                RS_CENTRAL, RS_QUEUE, RS_TAKED_DOWM, RS_WANT_SEE, RS_WATCHED, RS_WATCHING
            };
        }

        public static System.Net.IWebProxy GetProxy()
        {
            var proxy_host = GetSetting("proxy_host");
            var proxy = new System.Net.WebProxy(proxy_host);

            var proxy_credentials = GetSetting("proxy_credentials").Split(',');
            var credentials = new System.Net.NetworkCredential(proxy_credentials[0], proxy_credentials[1]);
            if (proxy_credentials.Length > 2 && String.IsNullOrEmpty(proxy_credentials[2])) credentials.Domain = proxy_credentials[2];
            proxy.Credentials = credentials;

            return proxy;
        }

        public static bool IsUsingProxy()
        {
            string value = GetSetting("useProxy");

            return Boolean.Parse(value);
        }

        /// <exception cref="System.Configuration.ConfigurationErrorsException">reaching the file</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SaveSetting(string key, string value)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = AppConfiguration;

            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified, false);
        }

        /// <exception cref="InvalidCastException"></exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        public static void SetProxy(System.Net.WebProxy proxy)
        {
            System.Net.NetworkCredential credentials;

            try
            {
                credentials = proxy.Credentials as System.Net.NetworkCredential;
                string proxy_credentials = String.Format("{0},{1},{2}", credentials.UserName, credentials.Password, credentials.Domain);
                string proxy_host = proxy.Address.Authority;

                SaveSetting("proxy_credentials", proxy_credentials);
                SaveSetting("proxy_host", proxy_host);
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Tries to reach all configurations, system and app files.
        /// </summary>
        /// <returns>true - if files exists, otherwise false.</returns>
        public static bool TryFileInspection()
        {
            return File.Exists(AppConfiguration);
        }

        #endregion


    }
}
