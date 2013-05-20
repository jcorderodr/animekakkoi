using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Framework.media;
using Framework.entity;

namespace Framework.util
{
    /// <summary>
    /// 
    /// </summary>
    public class WebImporter
    {

        public IMPORT_SOURCES Type { get; set; }

        /// <exception cref="System.Net.WebException">Trying to reach the indicated Uri.</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public string TryRequest(string uri)
        {

            WebClient client = new WebClient();
            string html;

            string sampleURL = "http://google.com";
            bool useProxy = !string.Equals(System.Net.WebRequest.DefaultWebProxy.GetProxy(new Uri(sampleURL)), sampleURL);
            if (useProxy)
            {
                client.Proxy = io.Configuration.GetProxy();
            }

            try
            {
                Stream data = client.OpenRead(uri);
                StreamReader reader = new StreamReader(data);
                html = reader.ReadToEnd();
                int init = html.IndexOf("<body");
                int end = html.IndexOf("</body>");
                html = html.Substring(init, end - init);
                data.Close();
                reader.Close();
            }
            catch (WebException ex) { throw ex; }

            return html;
        }


        /// <exception cref="System.Exception"></exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="typeName">the Entity's name.</param>
        /// <param name="rType"></param>
        /// <returns></returns>
        public Framework.media.ISource GetSource(string html, string typeName, ref Type rType)
        {
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
            return AnalizeSource(html, type);
        }

        private Framework.media.ISource AnalizeSource(string html, Type type)
        {
            try
            {
                switch (Type)
                {
                    case IMPORT_SOURCES.MCANIME:
                        McAnime mcanime = new McAnime();
                        if (type == typeof(Anime))
                            mcanime.DisassembleSource(html);
                        else if (type == typeof(Manga))
                            mcanime.DisassembleSource_Manga(html); ;
                        return mcanime;

                    case IMPORT_SOURCES.MCANIME_KRONOS:
                        McAnime mcanime_k = new McAnime();
                        if (type == typeof(Anime))
                            mcanime_k.DisassembleSourceKronos(html);
                        else if (type == typeof(Manga))
                            mcanime_k.DisassembleSourceKronos_Manga(html); ;
                        return mcanime_k;

                    case IMPORT_SOURCES.MY_ANIME_LIST:
                        MyAnimeList resx = new MyAnimeList();
                        if (type == typeof(Anime))
                            resx.DisassembleSource_Anime(html);
                        else if (type == typeof(Manga))
                            resx.DisassembleSource_Manga(html); ;
                        return resx;

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

        public static bool isValidateSources(IMPORT_SOURCES sources, string resource)
        {
            bool r = true;

            switch (sources)
            {
                case IMPORT_SOURCES.MCANIME:
                    return resource.Contains("mcanime");
                case IMPORT_SOURCES.MCANIME_KRONOS:
                    return resource.Contains("kronos");
                case IMPORT_SOURCES.MY_ANIME_LIST:
                    return resource.Contains("myanimelist");

                default:
                    r = false;
                    break;
            }
            return r;
        }

    }

    public enum IMPORT_SOURCES
    {
        MCANIME = 1,
        MCANIME_KRONOS = 2,
        MY_ANIME_LIST = 3
    }

}
