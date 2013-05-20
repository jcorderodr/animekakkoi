using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace Framework.io
{
    /// <summary>
    /// Provides mechanism for controling the outgoing localization.
    /// </summary>
    public class Language
    {

        private static String languageFilePath = "Language.lsp";

        private const String COMMENT_TAG = "#";

        private string[] splitters = new string[] { "=", "\r\n" };

        Dictionary<string, string> messagesLibrary;

        CultureInfo cultureInfo;

        #region Properties

        public Dictionary<string, string> ErrorsLibrary
        {
            get
            {
                return messagesLibrary;
            }
        }

        public Dictionary<string, string> MessagesLibrary
        {
            get
            {
                return messagesLibrary;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="IOException">IOException</exception>
        /// <exception cref="NotImplementedException">NotImplementedException</exception>
        public Language()
        {
            try
            {
                InitComponents();
                Load(cultureInfo);
            }
            catch (Exception ex) { throw ex; }
        }


        private void InitComponents()
        {
            cultureInfo = CultureInfo.CurrentCulture;
            messagesLibrary = new Dictionary<string, string>();
        }

        /// <exception cref="System.IO.IOException">reaching the lang file.</exception>
        /// <exception cref="NotImplementedException">if Language is not implemented</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        protected void Load(CultureInfo culture)
        {
            string file = Configuration.ApplicationDataFolder + languageFilePath;
            System.IO.StreamReader reader = null;

            try
            {
                reader = new System.IO.StreamReader(file, true);
            }
            catch (System.IO.IOException ex) { throw ex; }
            
            try
            {
                string aux = reader.ReadToEnd();
                int regionStart = aux.IndexOf(culture.Parent.Name);

                if (regionStart == -1)
                {
                    string user_culture_pre = io.Configuration.GetSetting("lang");
                    cultureInfo = new CultureInfo(user_culture_pre);
                }

                regionStart = aux.IndexOf(culture.Parent.Name);
                if (regionStart == -1)
                {
                    throw new NotImplementedException("Language is not implemented: " + cultureInfo.Parent.Name);
                }

                regionStart = aux.IndexOf(']', regionStart) + 1;
                int regionEnd = aux.IndexOf('[', regionStart);

                SplitWords(aux.Substring(regionStart, regionEnd - regionStart));
            }
            catch (NotImplementedException ex) { throw ex; }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
        }

        private void SplitWords(string text)
        {
            string[] words = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(COMMENT_TAG))
                    continue;

                messagesLibrary.Add(words[i].Trim(), words[++i].Trim());
            }
        }


    }
}
