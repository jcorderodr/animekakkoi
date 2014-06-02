using System;
using System.Net;
using System.Threading.Tasks;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.Media;

namespace AnimeKakkoi.Core.Util
{

    /// <summary>
    /// A web importer for loading media from web-based resources.
    /// </summary>
    public class WebImporter : IImporter
    {

        public ImportSources Type { get; set; }

        public String Html { get; set; }

        public String TryRequest(string uri)
        {
            return TryRequestAsync(uri).Result;
        }

        /// <exception cref="System.Net.WebException">Trying to reach the indicated Uri.</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<String> TryRequestAsync(string uri)
        {
            string html = null;

            var webRequest = WebRequest.Create(uri);
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            const string sampleUrl = "http://google.com";
            var useProxy = !string.Equals(objA: WebRequest.DefaultWebProxy.GetProxy(new Uri(sampleUrl)), objB: sampleUrl);
            if (useProxy)
            {
                //client.Proxy = IO.AkConfiguration.GetProxy();
            }

            var response = (HttpWebResponse)webRequest.GetResponseAsync().Result;
            var stream = response.GetResponseStream();
            
            try
            {
                using (var reader = new System.IO.StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                    reader.Dispose();
                    //
                    var init = html.IndexOf("<body", System.StringComparison.Ordinal);
                    var end = html.IndexOf("</body>", System.StringComparison.Ordinal);
                    html = html.Substring(init, end - init);
                }
            }
            catch (WebException ex) { throw; }

            return html;
        }


        /// <exception cref="System.NullReferenceException">NullReferenceException - if HTML's value is not supplied.</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeName">the Entity's name.</param>
        /// <param name="rType"></param>
        /// <returns></returns>
        public ISource GetSource(string typeName, ref Type rType)
        {
            if (String.IsNullOrEmpty(this.Html))
                throw new NullReferenceException("The HTML property's empty.");

            Type type;

            switch (typeName.ToLower())
            {
                case "anime":
                    type = typeof(Anime);
                    break;
                case "manga":
                    type = typeof(Manga);
                    break;
                default:
                    type = typeof(EntitySource);
                    break;
            }
            rType = type;
            return AnalizeSource(type);
        }

        private ISource AnalizeSource(Type type)
        {
            try
            {
                switch (Type)
                {
                    case ImportSources.MCANIME:
                        var mcanime = new McAnime();
                        if (type == typeof(Anime))
                            mcanime.DisassembleSource(this.Html);
                        else if (type == typeof(Manga))
                            mcanime.DisassembleSource_Manga(this.Html); ;
                        return mcanime;

                    case ImportSources.MCANIME_KRONOS:
                        var mcanimeK = new McAnime();
                        if (type == typeof(Anime))
                            mcanimeK.DisassembleSourceKronos(this.Html);
                        else if (type == typeof(Manga))
                            mcanimeK.DisassembleSourceKronos_Manga(this.Html); ;
                        return mcanimeK;

                    case ImportSources.MY_ANIME_LIST:
                        var animeList = new MyAnimeList();
                        if (type == typeof(Anime))
                            animeList.DisassembleSource_Anime(this.Html);
                        else if (type == typeof(Manga))
                            animeList.DisassembleSource_Manga(this.Html); ;
                        return animeList;

                    default:
                        return null;
                }
            }
            catch (NullReferenceException ex)
            {
                throw new MediaResourceException(ex, "HTML ERROR: " + Type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsValidateSources(ImportSources sources, string resource)
        {
            switch (sources)
            {
                case ImportSources.MCANIME:
                    return resource.Contains("mcanime");
                case ImportSources.MCANIME_KRONOS:
                    return resource.Contains("kronos");
                case ImportSources.MY_ANIME_LIST:
                    return resource.Contains("myanimelist");
                default:
                    return false;
            }
            return false;
        }

    }

    public enum ImportSources
    {
        MCANIME = 1,
        MCANIME_KRONOS = 2,
        MY_ANIME_LIST = 3
    }

}
