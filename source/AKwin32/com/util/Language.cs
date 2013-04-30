﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace AKwin32.com.util
{
    [Obsolete]
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


        public Dictionary<string, string> MessagesLibrary
        {
            get
            {
                return messagesLibrary;
            }
        }

        #endregion

        public Language()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            cultureInfo = CultureInfo.CurrentCulture;
            messagesLibrary = new Dictionary<string, string>();

            string file = Configuration.ApplicationDataFolder + languageFilePath;
            System.IO.StreamReader reader = new System.IO.StreamReader(file);
            //
            try
            {
                string aux = reader.ReadToEnd();
                int regionStart = aux.IndexOf(cultureInfo.Name);

                if (regionStart == -1)
                {
                    regionStart = aux.IndexOf(cultureInfo.Parent.Name);
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

                if (words[i].Contains(MESSAGE_TAG))
                    messagesLibrary.Add(words[i].Trim().Substring(MESSAGE_TAG.Length),
                        words[++i].Trim());
                else if (words[i].Contains(ERROR_TAG))
                    messagesLibrary.Add(words[i].Trim().Substring(ERROR_TAG.Length),
                        words[++i].Trim());

            }

        }

    }
}