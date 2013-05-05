using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Framework.entity;
using Framework.util;

namespace Framework.media
{
    /// <summary>
    /// 
    /// </summary>
    public class McAnime : SourceBase, ISource
    {

        #region Anime

        public readonly String FORM_SEARCH_EXPRESSION = "//form[@onsubmit=\"return checks(this);\"]";
        public readonly String HEADER_SEARCH_EXPRESSION = "//h3[@class=\"dd\"]";
        public readonly String ELEMENTS_SEARCH_EXPRESSION = "//ul[@class=\"dd_row anime_list\"]";

        public readonly String KRONOS_FORM_SEARCH_EXPRESSION = "//div[@class=\"series-block\"]";
        public readonly String KRONOS_HEADER_SEARCH_EXPRESSION = "//h3";
        public readonly String KRONOS_ELEMENTS_SEARCH_EXPRESSION = "//div[contains(@class, 'series-row')]";

        #endregion

        #region Manga

        public readonly String MANGA_FORM_SEARCH_EXPRESSION = "//form[@onsubmit=\"return checks(this);\"]";
        public readonly String MANGA_HEADER_SEARCH_EXPRESSION = "//h3[@class=\"dd\"]";
        public readonly String MANGA_ELEMENTS_SEARCH_EXPRESSION = "//ul[@class=\"dd_row anime_list\"]";

        public readonly String MANGA_KRONOS_FORM_SEARCH_EXPRESSION = "//div[@class=\"series-block\"]";
        public readonly String MANGA_KRONOS_HEADER_SEARCH_EXPRESSION = "//h3";
        public readonly String MANGA_KRONOS_ELEMENTS_SEARCH_EXPRESSION = "//div[contains(@class, 'series-row')]";


        #endregion

        public McAnime()
        {
            Items = new List<object>();
        }

        /// <exception cref="System.ArgumentException">When the web content hasen't the correct data.</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        public void DisassembleSource(string html)
        {
            //Take out the rules for the tag <form> 
            HtmlNode.ElementsFlags.Remove("form");
            //Parses the argument to HTML
            HtmlNode node = HtmlNode.CreateNode(html);
            // List of forms
            HtmlNodeCollection nodes = node.SelectNodes(FORM_SEARCH_EXPRESSION);

            if (nodes == null) throw new ArgumentException("the data given from the web wasn't the correct.");

            string aux;
            foreach (HtmlNode form in nodes)
            {

                aux = form.SelectSingleNode(form.XPath + HEADER_SEARCH_EXPRESSION).InnerText;
                Framework.entity.ENTITY_STATE state = this.StateCategories[aux];

                HtmlNodeCollection tag_ul = form.SelectNodes(form.XPath + ELEMENTS_SEARCH_EXPRESSION);

                entity.Anime temp;
                foreach (HtmlNode item in tag_ul)
                {
                    temp = new entity.Anime();

                    temp.Name = Expression.AnalizeNodeValue(item, item.XPath + "//a", "");
                    temp.State = state;
                    temp.Comment = "";

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//i", "Serie");
                    aux = aux.Replace("(", "").Replace(")", ""); ;
                    temp.Category = this.AnimeTypesCategories[aux];

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//li[@class=\"current_rating\"]", "0/0");
                    temp.Rating = Expression.GetOnlyNumbers(aux);

                    if (Expression.AnalizeNodeHtmlValue(item, item.XPath + "//li[@class=\"favorite\"]", "").Contains("fav"))
                        temp.Favorite = true;


                    this.Items.Add(temp);
                }
            }
        }

        public void DisassembleSource_Manga(string html)
        {
            //Take out the rules for the tag <form> 
            HtmlNode.ElementsFlags.Remove("form");
            //Parses the argument to HTML
            HtmlNode node = HtmlNode.CreateNode(html);
            // List of forms
            HtmlNodeCollection nodes = node.SelectNodes(MANGA_FORM_SEARCH_EXPRESSION);

            if (nodes == null) throw new ArgumentException("the data given from the web wasn't the correct.");

            string aux;
            foreach (HtmlNode form in nodes)
            {

                aux = form.SelectSingleNode(form.XPath + MANGA_HEADER_SEARCH_EXPRESSION).InnerText;

                Framework.entity.ENTITY_STATE state = this.StateCategories[aux];

                HtmlNodeCollection tag_ul = form.SelectNodes(form.XPath + MANGA_ELEMENTS_SEARCH_EXPRESSION);

                entity.Manga temp;
                foreach (HtmlNode item in tag_ul)
                {
                    temp = new entity.Manga();

                    temp.Name = Expression.AnalizeNodeValue(item, item.XPath + "//a", "");
                    temp.State = state;

                    // MCAnime v1 doesn't give the progress
                    temp.Chapters = new string[] { "-", "-" };

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//i", "Serie");
                    aux = aux.Replace("(", "").Replace(")", ""); ;
                    temp.Category = this.MangaTypeCategories[Expression.ToCapCase(aux)];

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//li[@class=\"current_rating\"]", "0/0");
                    temp.Rating = Expression.GetOnlyNumbers(aux);

                    if (Expression.AnalizeNodeHtmlValue(item, item.XPath + "//li[@class=\"favorite\"]", "").Contains("fav"))
                        temp.Favorite = true;

                    temp.Comment = "";

                    this.Items.Add(temp);
                }
            }

        }

        /// <exception cref="System.ArgumentException">When the web content hasen't the correct data.</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        public void DisassembleSourceKronos(string html)
        {
            //Parses the argument to HTML
            HtmlNode node = HtmlNode.CreateNode(html);
            // List of forms
            HtmlNodeCollection nodes = node.SelectNodes(KRONOS_FORM_SEARCH_EXPRESSION);

            if (nodes == null) throw new ArgumentException("the data given from the web wasn't the correct.");

            string aux;
            foreach (HtmlNode form in nodes)
            {

                aux = form.SelectSingleNode(form.XPath + KRONOS_HEADER_SEARCH_EXPRESSION).InnerText;
                entity.ENTITY_STATE state = this.StateCategories[aux];

                HtmlNodeCollection tag_ul = form.SelectNodes(form.XPath + KRONOS_ELEMENTS_SEARCH_EXPRESSION);

                entity.Anime temp;
                foreach (HtmlNode item in tag_ul)
                {
                    temp = new entity.Anime();

                    HtmlNodeCollection fields = item.SelectNodes(item.XPath + "//div");

                    if (fields[0].InnerText.Contains("#"))
                        continue;

                    temp.Name = Expression.AnalizeNodeValue(item, item.XPath + "//div[2]/a[1]", "");

                    if (Expression.AnalizeNodeHtmlValue(item, item.XPath + "//div[3]", "").Contains("fav"))
                        temp.Favorite = true;

                    temp.Rating = Expression.AnalizeNodeValue(item, item.XPath + "//div[4]", 0);
                    temp.State = state;

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//div[5]", "Serie");
                    temp.Category = this.AnimeTypesCategories[aux];

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//div[6]", "0/0");
                    temp.EpisodesString = Expression.GetOnlyNumbersText(aux);

                    temp.Comment = "";

                    this.Items.Add(temp);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        public void DisassembleSourceKronos_Manga(string html)
        {
            //Parses the argument to HTML
            HtmlNode node = HtmlNode.CreateNode(html);
            // List of forms
            HtmlNodeCollection nodes = node.SelectNodes(MANGA_KRONOS_FORM_SEARCH_EXPRESSION);

            if (nodes == null) throw new ArgumentException("the data given from the web wasn't the correct.");

            string aux;
            foreach (HtmlNode form in nodes)
            {

                aux = form.SelectSingleNode(form.XPath + MANGA_KRONOS_HEADER_SEARCH_EXPRESSION).InnerText;
                entity.ENTITY_STATE state = this.StateCategories[aux];

                HtmlNodeCollection tag_ul = form.SelectNodes(form.XPath + MANGA_KRONOS_ELEMENTS_SEARCH_EXPRESSION);

                entity.Manga temp;
                foreach (HtmlNode item in tag_ul)
                {
                    temp = new entity.Manga();

                    HtmlNodeCollection fields = item.SelectNodes(item.XPath + "//div");

                    if (fields[0].InnerText.Contains("#"))
                        continue;

                    temp.Name = Expression.AnalizeNodeValue(item, item.XPath + "//div[2]/a[1]", "");

                    if (Expression.AnalizeNodeHtmlValue(item, item.XPath + "//div[3]", "").Contains("fav"))
                        temp.Favorite = true;

                    temp.Rating = Expression.AnalizeNodeValue(item, item.XPath + "//div[4]", 0);
                    temp.State = state;

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//div[5]", "Serie");
                    temp.Category = this.MangaTypeCategories[Expression.ToCapCase(aux)];

                    aux = Expression.AnalizeNodeValue(item, item.XPath + "//div[6]", "0/0");
                    temp.ChapterString = aux;

                    temp.Comment = "";

                    this.Items.Add(temp);
                }
            }
        }

    }
}
