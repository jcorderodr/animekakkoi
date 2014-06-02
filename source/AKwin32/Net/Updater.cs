#region

using System;

#endregion

namespace AnimeKakkoi.App.Net
{

    /// <summary>
    /// 
    /// </summary>
    public class Update
    {

        public bool IsNewVersion { get; set; }

        public Version Version { get; set; }

        public static Update CheckForUpdate(string metaUrl)
        {
            var upd = new Update();

            try
            {
                var client = new System.Net.WebClient();
                string temp = client.DownloadString(metaUrl);
                client.Dispose();

                System.Xml.Linq.XElement doc = System.Xml.Linq.XElement.Parse(temp);
                doc = doc.Element("versions");
                System.Xml.Linq.XElement lastv = doc.Element("last-version");

                var actual = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                var last = new Version(lastv.Value);

                upd.IsNewVersion = (last > actual);
                upd.Version = last;
            }
            catch
            {
                throw;
            }

            return upd;
        }
    }
}