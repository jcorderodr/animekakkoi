using System;
using System.Collections.Generic;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.Helpers;
using AnimeKakkoi.Core.Util;
using HtmlAgilityPack;

namespace AnimeKakkoi.Core.Media
{

    public class McAnime : SourceBase, ISource
    {

        #region Anime

        public readonly String FormSearchExpression = "//form[@onsubmit=\"return checks(this);\"]";
        public readonly String HeaderSearchExpression = "//h3[@class=\"dd\"]";
        public readonly String ElementsSearchExpression = "//ul[@class=\"dd_row anime_list\"]";

        public readonly String KronosFormSearchExpression = "//div[@class=\"series-block\"]";
        public readonly String KronosHeaderSearchExpression = "//h3";
        public readonly String KronosElementsSearchExpression = "//div[contains(@class, 'series-row')]";

        #endregion

        #region Manga

        public readonly String MangaFormSearchExpression = "//form[@onsubmit=\"return checks(this);\"]";
        public readonly String MangaHeaderSearchExpression = "//h3[@class=\"dd\"]";
        public readonly String MangaElementsSearchExpression = "//ul[@class=\"dd_row anime_list\"]";

        public readonly String MangaKronosFormSearchExpression = "//div[@class=\"series-block\"]";
        public readonly String MangaKronosHeaderSearchExpression = "//h3";
        public readonly String MangaKronosElementsSearchExpression = "//div[contains(@class, 'series-row')]";

        public IEnumerable<object> ResultedItems
        {
            get { return Items; }
            private set { }
        }

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
            HtmlNodeCollection nodes = node.SelectNodes(FormSearchExpression);

            if (nodes == null) throw new ArgumentException("the data given from the web wasn't the correct.");

            string aux;
            foreach (HtmlNode form in nodes)
            {

                aux = form.SelectSingleNode(form.XPath + HeaderSearchExpression).InnerText;
                var state = this.StateCategories[aux];

                HtmlNodeCollection tag_ul = form.SelectNodes(form.XPath + ElementsSearchExpression);

                foreach (HtmlNode item in tag_ul)
                {
                    var entity = new Entities.Anime();

                    entity.Name = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//a", "");
                    entity.State = state;
                    entity.Comment = "";

                    aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//i", "Serie");
                    aux = aux.Replace("(", "").Replace(")", ""); ;
                    entity.Category = this.AnimeTypesCategories[aux];

                    aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//li[@class=\"current_rating\"]", "0/0");
                    entity.Rating = StringHelper.GetOnlyNumbers(aux);

                    if (HNodeHelper.AnalizeNodeHtmlValue(item, item.XPath + "//li[@class=\"favorite\"]", "").Contains("fav"))
                        entity.Favorite = true;


                    this.Items.Add(entity);
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
            HtmlNodeCollection nodes = node.SelectNodes(MangaFormSearchExpression);

            if (nodes == null) throw new ArgumentException("the data given from the web wasn't the correct.");

            string aux;
            foreach (HtmlNode form in nodes)
            {

                aux = form.SelectSingleNode(form.XPath + MangaHeaderSearchExpression).InnerText;

                var state = this.StateCategories[aux];

                HtmlNodeCollection tagUl = form.SelectNodes(form.XPath + MangaElementsSearchExpression);

                foreach (HtmlNode item in tagUl)
                {
                    var entity = new Entities.Manga();

                    entity.Name = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//a", "");
                    entity.State = state;

                    //TODO: Check this out
                    // MCAnime v1 doesn't give the progress
                    //entity.Chapters = new string[] { "-", "-" };

                    aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//i", "Serie");
                    aux = aux.Replace("(", "").Replace(")", ""); ;
                    entity.Category = this.MangaTypeCategories[StringHelper.ToCapCase(aux)];

                    aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//li[@class=\"current_rating\"]", "0/0");
                    entity.Rating = StringHelper.GetOnlyNumbers(aux);

                    if (HNodeHelper.AnalizeNodeHtmlValue(item, item.XPath + "//li[@class=\"favorite\"]", "").Contains("fav"))
                        entity.Favorite = true;

                    entity.Comment = "";

                    this.Items.Add(entity);
                }
            }

        }

        /// <exception cref="MediaResourceException">When the web content hasen't the correct data.</exception>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        public void DisassembleSourceKronos(string html)
        {
            //Parses the argument to HTML
            HtmlNode node = HtmlNode.CreateNode(html);
            // List of forms
            HtmlNodeCollection nodes = node.SelectNodes(KronosFormSearchExpression);

            if (nodes == null) throw new MediaResourceException(new ArgumentException("the data given from the web wasn't the correct."));

            foreach (HtmlNode form in nodes)
            {

                var aux = form.SelectSingleNode(form.XPath + KronosHeaderSearchExpression).InnerText;
                var state = this.StateCategories[aux];

                HtmlNodeCollection tag_ul = form.SelectNodes(form.XPath + KronosElementsSearchExpression);

                foreach (HtmlNode item in tag_ul)
                {
                    var entity = new Entities.Anime();

                    HtmlNodeCollection fields = item.SelectNodes(item.XPath + "//div");

                    if (fields[0].InnerText.Contains("#"))
                        continue;

                    entity.Name = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[2]/a[1]", "");

                    if (HNodeHelper.AnalizeNodeHtmlValue(item, item.XPath + "//div[3]", "").Contains("fav"))
                        entity.Favorite = true;

                    entity.Rating = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[4]", 0);
                    entity.State = state;

                    try
                    {
                        aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[5]", "Serie");
                        entity.Category = this.AnimeTypesCategories[aux];
                    }
                    catch (Exception)
                    {
                        entity.Category = AnimeType.Serie;
                        //TODO: Register error
                    }

                    aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[6]", "0/0");
                    entity.ProgressString = StringHelper.GetTextInChapterFormat(aux);

                    entity.Comment = "";

                    this.Items.Add(entity);
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
            HtmlNodeCollection nodes = node.SelectNodes(MangaKronosFormSearchExpression);

            if (nodes == null) throw new MediaResourceException(new ArgumentException("the data given from the web wasn't the correct."));

            foreach (HtmlNode form in nodes)
            {

                var aux = form.SelectSingleNode(form.XPath + MangaKronosHeaderSearchExpression).InnerText;
                var state = this.StateCategories[aux];

                var tagUl = form.SelectNodes(form.XPath + MangaKronosElementsSearchExpression);

                foreach (HtmlNode item in tagUl)
                {
                    var entity = new Entities.Manga();

                    HtmlNodeCollection fields = item.SelectNodes(item.XPath + "//div");

                    if (fields[0].InnerText.Contains("#"))
                        continue;

                    entity.Name = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[2]/a[1]", "");

                    if (HNodeHelper.AnalizeNodeHtmlValue(item, item.XPath + "//div[3]", "").Contains("fav"))
                        entity.Favorite = true;

                    entity.Rating = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[4]", 0);
                    entity.State = state;

                    aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[5]", "Serie");
                    entity.Category = this.MangaTypeCategories[StringHelper.ToCapCase(aux)];

                    aux = HNodeHelper.AnalizeNodeValue(item, item.XPath + "//div[6]", "0/0");
                    entity.ProgressString = aux;

                    entity.Comment = "";

                    this.Items.Add(entity);
                }
            }
        }


    }
}
