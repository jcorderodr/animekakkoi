using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimeKakkoi.Core.Helpers
{
    public class WebHelper
    {


        public static async Task<String> RequestHtmlBody(String uri)
        {
            var webRequest = WebRequest.Create(uri);
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            const string sampleUrl = "http://google.com";
            var useProxy = !string.Equals(objA: WebRequest.DefaultWebProxy.GetProxy(new Uri(sampleUrl)), objB: sampleUrl);
            if (useProxy)
            {
                //client.Proxy = IO.AkConfiguration.GetProxy();
            }

            var result = await webRequest.GetResponseAsync();
            var response = (HttpWebResponse)result;
            var stream = response.GetResponseStream();

            try
            {
                using (var reader = new System.IO.StreamReader(stream))
                {
                    string html = reader.ReadToEnd();
                    reader.Dispose();
                    //
                    var init = html.IndexOf("<body", System.StringComparison.Ordinal);
                    var end = html.IndexOf("</body>", System.StringComparison.Ordinal);
                    return html.Substring(init, end - init);
                }
            }
            catch (WebException ex) 
            { throw; }
        }

    }
}
