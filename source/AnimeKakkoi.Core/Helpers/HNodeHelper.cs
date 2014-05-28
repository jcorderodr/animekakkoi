using System;
using HtmlAgilityPack;

namespace AnimeKakkoi.Core.Helpers
{
    public class HNodeHelper
    {

        public static String AnalizeNodeValue(HtmlNode item, string xpath, string ifnull)
        {
            item = item.SelectSingleNode(xpath);
            return item == null ? ifnull : StringHelper.StringWithoutInvalidChars(item.InnerText);
        }

        public static String AnalizeNodeHtmlValue(HtmlNode item, string xpath, string ifnull)
        {
            item = item.SelectSingleNode(xpath);
            return item == null ? ifnull : StringHelper.StringWithoutInvalidChars(item.InnerHtml);
        }

        public static int AnalizeNodeValue(HtmlNode item, string xpath, int ifnull)
        {
            item = item.SelectSingleNode(xpath);
            try
            {
                return Convert.ToInt32(item.InnerText);
            }
            catch
            {
                return ifnull;
            }
        }

    }
}