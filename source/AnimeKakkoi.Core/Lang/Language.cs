using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using AnimeKakkoi.Core.IO;

namespace AnimeKakkoi.Core.Lang
{
    /// <summary>
    /// Provides mechanism for controling the outgoing localization.
    /// </summary>
    public class Language
    {

        private const String LanguageFilePath = "Language.lsp";

        private const String CommentTag = "#";

        private readonly string[] _splitters = new string[] { "=", "\r\n" };

        CultureInfo _cultureInfo;

        #region Properties

        public Dictionary<string, string> ErrorsLibrary
        {
            get
            {
                return MessagesLibrary;
            }
        }

        public Dictionary<string, string> MessagesLibrary { get; private set; }

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

        #region Private Functions

        private void InitComponents()
        {
            _cultureInfo = CultureInfo.DefaultThreadCurrentCulture;
            MessagesLibrary = new Dictionary<string, string>();
        }

        private void SplitWords(string text)
        {
            var words = text.Split(_splitters, StringSplitOptions.RemoveEmptyEntries);

            //MessagesLibrary = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(string.Join(Environment.NewLine, words))

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(CommentTag, StringComparison.CurrentCultureIgnoreCase))
                    continue;

                MessagesLibrary.Add(words[i].Trim(), words[++i].Trim());
            }
        }

        #endregion

        #region Public Functions

        /// <exception cref="System.IO.IOException">reaching the lang file.</exception>
        /// <exception cref="NotImplementedException">if Language is not implemented</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        protected void Load(CultureInfo culture)
        {
            var file = AkConfiguration.ApplicationDataFolder + LanguageFilePath;

            var taskStream = FileManager.OpenStream(file);
            var stream = taskStream.Result;

            int regionStart, regionEnd;

            regionStart = stream.IndexOf(culture.Parent.Name, System.StringComparison.Ordinal);

            if (regionStart == -1)
            {
                throw new NotImplementedException("Language is not implemented: " + culture.Parent.Name);
            }

            regionStart = stream.IndexOf(']', regionStart) + 1;
            regionEnd = stream.IndexOf('[', regionStart);

            if (regionEnd == -1)
                regionEnd = stream.Length;
            //
            SplitWords(stream.Substring(regionStart, regionEnd - regionStart));
        }

        public void Reload(CultureInfo newCulture)
        {
            _cultureInfo = newCulture;
            Load(_cultureInfo);
        }

        #endregion

    }
}
