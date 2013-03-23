using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Framework.io
{
    public class Configuration
    {
        public const String AppName = "AnimeKakkoi";

        internal const String AppConfig = @"C:\Users\Anib0warE\Documents\Proyectos\AnimeKakkoi\source\Framework\Framework.config";
        public const String Rsource = @"C:\Users\Anib0warE\Documents\Proyectos\AnimeKakkoi\resources\";

        protected const String rs_queue = "ak_queue.ak";
        protected const String rs_watched = "ak_watched.ak";
        protected const String rs_watching = "ak_watching.ak";



        internal static string GetSetting(string key)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = AppConfig;


            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value;
        }

        public static string GetAkFile(Framework.entity.ANIME_STATE state)
        {
            switch (state)
            {
                case entity.ANIME_STATE.QUEUE:
                    return rs_queue;
                case entity.ANIME_STATE.WATCHING:
                    return rs_watching;
                case entity.ANIME_STATE.WATCHED:
                    return rs_watched;
                default:
                    return "ak_queue.ak";
            }
        }


    }
}
