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
    public class Importer
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
                WebProxy proxy = new WebProxy("172.17.200.81", 8080);
                NetworkCredential credentials = new NetworkCredential("jcordero", "Bluegle77", "apap-pdc");
                proxy.Credentials = credentials;
                client.Proxy = proxy;
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
        /// <returns></returns>
        public Framework.media.ISource GetSource(string html, string typeName)
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
                    type = typeof(Anime);
                    break;
            }
            return AnalizeSource(html, type);
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
                    type = typeof(Anime);
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
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    public enum IMPORT_SOURCES
    {
        MCANIME = 1,
        MCANIME_KRONOS = 2
    }

}
