using System;
using System.Linq;
using System.Text;

namespace AnimeKakkoi.Core.Helpers
{
    /// <summary>
    /// Provides RegularExpression, filter mechanism and functions to manipulate values.
    /// </summary>
    public abstract class StringHelper
    {
       
        public static String StringIfNull(object item, string ifnull)
        {
            try { return item.ToString(); }
            catch { return ifnull; }
        }

        public static int IfIntegerNull(object item, int ifnull)
        {
            try { return Convert.ToInt32(item); }
            catch { return ifnull; }
        }

        public static int GetOnlyNumbers(string text)
        {
            var reg = new System.Text.RegularExpressions.Regex("([^0-9])");
            text = reg.Replace(text, "");
            try { return Convert.ToInt32(text); }
            catch { return 0; }
        }

        public static String GetTextInChapterFormat(string text)
        {
            text = text.Replace("-", "0");
            var reg = new System.Text.RegularExpressions.Regex("([^0-9+/][^-]|-)");
            text = reg.Replace(text, "");
            return text;
        }

        public static String GetOnlyText(string text)
        {
            var reg = new System.Text.RegularExpressions.Regex("([^A-Za-z]+' ')");
            text = reg.Replace(text, "");
            return text;
        }

        /// <summary>
        /// Converts to title case.
        /// </summary>
        /// <remarks></remarks>
        public static String ToCapCase(string value)
        {
            if (value == null)
                return null;
            if (value.Length == 0)
                return value;

            var result = new StringBuilder(value);
            result[0] = char.ToUpper(result[0]);
            for (int i = 1; i < result.Length; ++i)
            {
                result[i] = char.IsWhiteSpace(result[i - 1]) ? 
                    char.ToUpper(result[i]) : char.ToLower(result[i]);
            }
            return result.ToString();
        }

        public static String StringWithoutInvalidChars(String text)
        {
            var chars = new[] { "&nbsp;" };
            return chars.Aggregate(text, (current, s) => current.Replace(s, ""));
        }

    }
}
