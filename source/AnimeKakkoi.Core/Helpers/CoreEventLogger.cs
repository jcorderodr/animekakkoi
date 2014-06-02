using System;

namespace AnimeKakkoi.Core.Helpers
{
    public class CoreEventLogger
    {
        public static void Write(string file, string text)
        {
            try
            {
                //System.IO.File.AppendAllText(file,
                //                             String.Format("{1:dd/mm/yyyy hh:mm} # {0}{2}", text,
                //                                           DateTimeOffset.Now.DateTime,
                //                                           Environment.NewLine));
            }
            catch
            {
            }
        }
        public static void Write(string text)
        {

            //System.IO.File.AppendAllText(IO.AkConfiguration.ApplicationLoggerFile,
            //                             String.Format("{1:dd/mm/yyyy hh:mm} # {0}{2}", text,
            //                                           DateTimeOffset.Now.DateTime,
            //                                           Environment.NewLine));

        }
        
     
    }
}