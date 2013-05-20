using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace Framework.io
{
    /// <summary>
    /// Provides access, properties and settings.
    /// </summary>
    public abstract class Configuration
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


        internal const String PROPERTIES_SECTION_MAIN_DATA = "Properties";
        internal const bool APP_REPO_AUTOSAVE = true;

        public static String ApplicationDataFolder
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                //C:\ProgramData\BluegleTek Soft\AnimeKakkoi
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

        #region Functions

        public static String GetSetting(string key)
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

        internal static String[] GetBackUpFiles()
        {
            return new string[] 
            {
                RS_CENTRAL, RS_QUEUE, RS_TAKED_DOWM, RS_WANT_SEE, RS_WATCHED, RS_WATCHING
            };
        }

        public static System.Net.IWebProxy GetProxy()
        {
            string proxy_host = GetSetting("proxy_host");
            System.Net.WebProxy proxy = new System.Net.WebProxy(proxy_host);

            string[] proxy_credentials = GetSetting("proxy_credentials").Split(',');
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(proxy_credentials[0], proxy_credentials[1]);
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

            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
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
