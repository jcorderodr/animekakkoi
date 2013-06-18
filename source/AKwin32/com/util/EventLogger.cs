using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AKwin32.com.util
{
    public class EventLogger
    {

        public static void Write(string file, string text)
        {
            try
            {
                System.IO.File.AppendAllText(file, String.Format("{1:dd/mm/yyyy hh:mm} # {0}{2}", text, DateTime.Now, 
                    Environment.NewLine));
            }
            catch { }
        }


        public static void SystemWrite(string text)
        {
            EventInstance evt = new EventInstance(0, 0);
            EventLog.WriteEvent(Configuration.ApplicationName, evt, text);
        }

    }
}
