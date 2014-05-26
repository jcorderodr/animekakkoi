using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace AnimeKakkoi.Framework.IO
{
    /// <summary>
    /// Provides mechanism for controling the outgoing localization.
    /// </summary>
    public class Language
    {

        private const String LanguageFilePath = "Language.lsp";

        private const String CommentTag = "#";

        private readonly string[] _splitters = new string[] { "=", "\r\n" };

        Dictionary<string, string> _messagesLibrary;

        CultureInfo _cultureInfo;

        #region Properties

        public Dictionary<string, string> ErrorsLibrary
        {
            get
            {
                return _messagesLibrary;
            }
        }

        public Dictionary<string, string> MessagesLibrary
        {
            get
            {
                return _messagesLibrary;
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
                Load(_cultureInfo);
            }
            catch (Exception ex) { throw new Exception("LSP Load. " + ex.Message, ex); }
        }

        #region Functions

        private void InitComponents()
        {
            //another way: cultureInfo = new System.Globalization.CultureInfo(Framework.io.AkConfiguration.GetSetting("lang"));
            _cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            _messagesLibrary = new Dictionary<string, string>();
        }

        /// <exception cref="System.IO.IOException">reaching the lang file.</exception>
        /// <exception cref="NotImplementedException">if Language is not implemented</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        protected void Load(CultureInfo culture)
        {
            string file = AkConfiguration.ApplicationDataFolder + LanguageFilePath;
            System.IO.StreamReader reader = null;

            try
            {
                reader = new System.IO.StreamReader(file, true);
            }
            catch (System.IO.IOException ex) { throw new Exception("Streaming", ex); }

            try
            {
                string aux;
                int regionStart, regionEnd;

                aux = reader.ReadToEnd();

                regionStart = aux.IndexOf(culture.Parent.Name);

                if (regionStart == -1)
                {
                    throw new NotImplementedException("Language is not implemented: " + culture.Parent.Name);
                }

                regionStart = aux.IndexOf(']', regionStart) + 1;
                regionEnd = aux.IndexOf('[', regionStart);

                if (regionEnd == -1)
                    regionEnd = aux.Length;

                SplitWords(aux.Substring(regionStart, regionEnd - regionStart));

            }
            catch (NotImplementedException ex) { throw ex; }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
        }

        public void Reload(CultureInfo newCulture)
        {
            _cultureInfo = newCulture;
            Load(_cultureInfo);
        }

        private void SplitWords(string text)
        {
            string[] words = text.Split(_splitters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(CommentTag))
                    continue;

                _messagesLibrary.Add(words[i].Trim(), words[++i].Trim());
            }
        }

        #endregion

    }
}
