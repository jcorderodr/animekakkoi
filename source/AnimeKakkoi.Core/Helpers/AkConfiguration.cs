using System;
using System.Collections.Generic;

namespace AnimeKakkoi.Core.IO
{

    /// <summary>
    /// Provides access, properties and settings.
    /// </summary>
    public class AkConfiguration
    {

        public const String COMPANY_NAME = "Corderoski";
        public const String APPLICATION_NAME = "AnimeKakkoi";

        private const String AppConfigFileName = "anime_k.akc";

        /// <summary>
        /// 
        /// </summary>
        internal static String AppConfigurationFile
        {
            get
            {
                return ApplicationDataFolder + AppConfigFileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static String AppLoggerFile
        {
            get { return ApplicationDataFolder + "usr-h.log"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static String ApplicationDataFolder
        {
            get
            {
                var path = IO.FileManager.GetFolder(String.Format("..\\",
                    IO.FileManager.GetPathSeparatorChar(), COMPANY_NAME, APPLICATION_NAME));
                return path;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static System.Globalization.CultureInfo ApplicationDefaultCulture
        {
            get 
            { 
                var cultureInfo = new System.Globalization.CultureInfo(GetSetting("ApplicationCulture"));
                return cultureInfo ?? new System.Globalization.CultureInfo("en");
            }
        }


        #region Functions

        protected internal static String GetSetting(string key)
        {
            var openStreamResult = IO.FileManager.OpenStream(AppConfigurationFile);

            if (openStreamResult.IsFaulted || openStreamResult.Result == null)
            {
                var content = Newtonsoft.Json.JsonConvert.SerializeObject(new Entities.Configuration());
                IO.FileManager.SaveStream(AppConfigurationFile, content);
                openStreamResult = IO.FileManager.OpenStream(AppConfigurationFile);
            }

            var dictionary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(openStreamResult.Result);

            return dictionary.ContainsKey(key) ? dictionary[key] : String.Empty;
        }

        public static bool IsUsingProxy()
        {
            var value = GetSetting("useProxy");
            return Boolean.Parse(value);
        }

        public static bool ReleaseAllApplicationResources()
        {
            IO.FileManager.CleanApplicationData();
            return true;
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

        /// <summary>
        /// Tries to reach all configurations, system and app files.
        /// </summary>
        /// <returns>true - if files exists, otherwise false.</returns>
        public static bool TryFileInspection()
        {
            return FileManager.FileExists(AkConfiguration.ApplicationDataFolder + Lang.Language.LanguageFileName);
        }
        
        #endregion


    }
}
