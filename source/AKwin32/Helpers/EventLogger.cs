#region

using System;
using System.Diagnostics;
using AnimeKakkoi.Framework.IO;

#endregion

namespace AnimeKakkoi.App.Helpers
{
    public class EventLogger
    {
        public static void Write(string file, string text)
        {
            try
            {
                System.IO.File.AppendAllText(file,
                                             String.Format("{1:dd/mm/yyyy hh:mm} # {0}{2}", text,
                                                           DateTimeOffset.Now.DateTime,
                                                           Environment.NewLine));
            }
            catch
            {
            }
        }


        public static void SystemWrite(string text)
        {
            var evt = new EventInstance(0, 0);
            EventLog.WriteEvent(AkConfiguration.APPLICATION_NAME, evt, text);
        }
    }
}