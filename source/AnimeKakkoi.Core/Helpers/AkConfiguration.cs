using System;
using System.Collections.Generic;

namespace AnimeKakkoi.Core.IO
{
    /// <summary>
    /// Provides access, properties and settings.
    /// </summary>
    public sealed class AkConfiguration
    {

        public const String COMPANY_NAME = "Corderoski";
        public const String APPLICATION_NAME = "AnimeKakkoi";

        private const String AppConfigFileName = "anime_k.akc";

        internal const String RS_CENTRAL = "ak_data.bin";
        internal const String RS_ANIMES = "ak_animes.akm";
        internal const String RS_MANGAS = "ak_mangas.akm";


        internal const String PROPERTIES_SECTION_MAIN_DATA = "Properties";
        internal const bool APP_REPO_AUTOSAVE = true;

        public static String ApplicationDataFolder
        {
            get
            {
                var path = IO.FileManager.GetFolder(String.Format("{1}{0}{2}{0}",
                    IO.FileManager.GetPathSeparatorChar(), COMPANY_NAME, APPLICATION_NAME));
                return path;
            }
        }

        internal static String AppConfigurationFile
        {
            get
            {
                return ApplicationDataFolder + AppConfigFileName;
            }
        }

        #region Functions

        public static String GetSetting(string key)
        {
            var openStreamResult = IO.FileManager.OpenStream(AppConfigurationFile);

            var dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(openStreamResult.Result);

            return dictionary[key];
        }

        internal static String[] GetBackUpFiles()
        {
            return new string[] 
            {
                RS_CENTRAL, RS_ANIMES, RS_MANGAS
            };
        }

        public static System.Net.IWebProxy GetProxy()
        {
            //TODO: Implement
            /*
            var proxy_host = GetSetting("proxy_host");
            var proxy = new System.Net.WebProxy(proxy_host);

            var proxy_credentials = GetSetting("proxy_credentials").Split(',');
            var credentials = new System.Net.NetworkCredential(proxy_credentials[0], proxy_credentials[1]);
            if (proxy_credentials.Length > 2 && String.IsNullOrEmpty(proxy_credentials[2])) credentials.Domain = proxy_credentials[2];
            proxy.Credentials = credentials;

            return proxy;
             * */
            return null;
        }

        public static bool IsUsingProxy()
        {
            var value = GetSetting("useProxy");
            return Boolean.Parse(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SaveSetting(string key, string value)
        {
            //TODO: Implement
        }

        /// <exception cref="InvalidCastException"></exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proxy"></param>
        public static void SetProxy(System.Net.IWebProxy proxy, string host)
        {
            System.Net.NetworkCredential credentials;
            
            try
            {
                credentials = proxy.Credentials as System.Net.NetworkCredential;
                var proxyCredentials = String.Format("{0},{1},{2}", credentials.UserName, credentials.Password, credentials.Domain);
                var proxyHost = host;

                SaveSetting("proxy_credentials", proxyCredentials);
                SaveSetting("proxy_host", proxyHost);
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
            return FileManager.FileExists(AppConfigurationFile);
        }

        #endregion


    }
}
