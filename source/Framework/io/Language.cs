using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace Framework.io
{
    public class Language
    {

        private static String languageFilePath = "Language.lsp";

        private const String COMMENT_TAG = "#";
        private const String ERROR_TAG = "error_";
        private const String MESSAGE_TAG = "message_";

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
            }
            catch (IOException ex) { throw ex; }
        }


        private void InitComponents()
        {
            cultureInfo = CultureInfo.CurrentCulture;
            messagesLibrary = new Dictionary<string, string>();

            string file = Configuration.ApplicationDataFolder + languageFilePath;
            System.IO.StreamReader reader = null;
            
            try
            {
                reader = new System.IO.StreamReader(file, Encoding.UTF8);
            }
            catch (System.IO.IOException ex) { throw ex; }
            //
            try
            {
                string aux = reader.ReadToEnd();
                int regionStart = aux.IndexOf(cultureInfo.Parent.Name);

                if (regionStart == -1)
                {
                    throw new NotImplementedException("Language is not implemented: " + cultureInfo.Parent.Name);
                }

                regionStart = aux.IndexOf(']', regionStart) + 1;
                int regionEnd = aux.IndexOf('[', regionStart);

                SplitWords(aux.Substring(regionStart, regionEnd - regionStart));
            }
            catch { }
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
