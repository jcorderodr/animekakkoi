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
