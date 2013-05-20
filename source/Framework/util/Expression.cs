using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Framework.util
{
    public abstract class Expression
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

        public static String AnalizeNodeValue(HtmlNode item, string xpath, string ifnull)
        {
            item = item.SelectSingleNode(xpath);
            return item == null ? ifnull : StringWithoutIvalidChars(item.InnerText);
        }

        public static String AnalizeNodeHtmlValue(HtmlNode item, string xpath, string ifnull)
        {
            item = item.SelectSingleNode(xpath);
            return item == null ? ifnull : StringWithoutIvalidChars(item.InnerHtml);
        }

        public static int AnalizeNodeValue(HtmlNode item, string xpath, int ifnull)
        {
            item = item.SelectSingleNode(xpath);
            try { return Convert.ToInt32(item.InnerText); }
            catch { return ifnull; }
        }

        public static int GetOnlyNumbers(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("([^0-9])");
            text = reg.Replace(text, "");
            try { return Convert.ToInt32(text); }
            catch { return 0; }
        }

        public static String GetTextInChapterFormat(string text)
        {
            text = text.Replace("-", "0");
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("([^0-9+/][^-]|-)");
            text = reg.Replace(text, "");
            return text;
        }

        public static String GetOnlyText(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("([^A-Za-z]+' ')");
            text = reg.Replace(text, "");
            return text;
        }

        public static String ToCapCase(string text)
        {
            //aux = aux.FirstOrDefault().ToString().ToUpper() + aux.Substring(1);
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        private static String StringWithoutIvalidChars(String text)
        {
            string[] chars = new[] { "&nbsp;" };
            foreach (string s in chars)
                text = text.Replace(s, "");
            return text;
        }



    }
}
