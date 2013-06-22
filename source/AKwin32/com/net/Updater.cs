using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AKwin32.com.net
{
    /// <summary>
    /// 
    /// @version 1.0
    /// </summary>
    public class Update
    {

        public bool IsNewVersion { get; set; }
        public Version Version { get; set; }

        public Update()
        {

        }

        public static Update CheckForUpdate(string metaUrl)
        {
            Update upd = new Update();

            try
            {
                System.Net.WebClient client = new System.Net.WebClient();
                string temp = client.DownloadString(metaUrl);
                client.Dispose();

                System.Xml.Linq.XElement doc = System.Xml.Linq.XElement.Parse(temp);
                doc = doc.Element("versions");
                System.Xml.Linq.XElement lastv = doc.Element("last-version");

                Version actual = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                Version last = new Version(lastv.Value);

                upd.IsNewVersion = (last > actual);
                upd.Version = last;

            }
            catch { }

            return upd;
        }

    }
}
