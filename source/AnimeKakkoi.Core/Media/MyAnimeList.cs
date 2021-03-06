﻿using System;
using System.Collections.Generic;
using AnimeKakkoi.Core.Helpers;
using AnimeKakkoi.Core.Util;
using HtmlAgilityPack;

namespace AnimeKakkoi.Core.Media
{
    public class MyAnimeList : SourceBase, ISource
    {

        public readonly String FORM_SEARCH_EXPRESSION = "//div[@id=\"list_surround\"]//table";
        public readonly String HEADER_SEARCH_EXPRESSION = "//div[@id=\"list_surround\"]//table[1]//a";
        public readonly String ELEMENTS_SEARCH_EXPRESSION = "//a[@class=\"animetitle\"]";
        
        public IEnumerable<object> ResultedItems
        {
            get { return Items; }
        }

        public MyAnimeList()
        {
            Items = new List<object>();
        }

        public void DisassembleSource_Anime(string html)
        {
            HtmlNode node = HtmlNode.CreateNode(html);
            HtmlNode form = node.SelectSingleNode(FORM_SEARCH_EXPRESSION + "[1]");

            if (form == null) throw new MediaResourceException(new ArgumentException("the data given from the resource wasn't in the right format."));

            HtmlNodeCollection headers = form.SelectNodes(HEADER_SEARCH_EXPRESSION);
            string aux;
            foreach (HtmlNode section in headers)
            {

                aux = section.InnerText;
                if (!this.StateCategories.ContainsKey(aux)) continue; //avoiding some references inexistent like 'All Anime'
                var state = this.StateCategories[aux];

                string uri = "http://myanimelist.net" + section.Attributes["href"].Value;
                WebImporter requester = new WebImporter();
                string request_html = requester.TryRequest(uri);

                HtmlNode inner_node = HtmlNode.CreateNode(request_html);
                HtmlNodeCollection inner_form = inner_node.SelectNodes(FORM_SEARCH_EXPRESSION);

                Entities.Anime temp;
                foreach (HtmlNode item in inner_form)
                {
                    HtmlNode item_section = item.SelectSingleNode(item.XPath + ELEMENTS_SEARCH_EXPRESSION);
                    if (item_section == null)
                        continue;

                    item_section = item.SelectSingleNode(item.XPath + "//tr");

                    temp = new Entities.Anime();
                    temp.Name = item_section.SelectSingleNode(item_section.XPath + "//span[1]").InnerText;
                    temp.State = state;

                    aux = HNodeHelper.AnalizeNodeValue(item_section, item_section.XPath + "//td[3]", "0");
                    temp.Rating = StringHelper.GetOnlyNumbers(aux);

                    aux = HNodeHelper.AnalizeNodeValue(item_section, item_section.XPath + "//td[4]", "TV");
                    temp.Category = this.AnimeTypesCategories[aux];

                    aux = HNodeHelper.AnalizeNodeValue(item_section, item_section.XPath + "//td[5]", "-/-");
                    temp.ProgressString = aux;

                    aux = HNodeHelper.AnalizeNodeValue(item_section, item_section.XPath + "//td[6]", "");
                    temp.Comment = aux;

                    this.Items.Add(temp);
                }
            }
        }

        public void DisassembleSource_Manga(string html)
        {
            HtmlNode node = HtmlNode.CreateNode(html);
            HtmlNode form = node.SelectSingleNode(FORM_SEARCH_EXPRESSION + "[1]");

            if (form == null) throw new MediaResourceException(new ArgumentException("the data given from the resource wasn't in the right format."));

            HtmlNodeCollection headers = form.SelectNodes(HEADER_SEARCH_EXPRESSION);
            string aux;
            foreach (HtmlNode section in headers)
            {
                aux = section.InnerText;
                if (!this.StateCategories.ContainsKey(aux)) continue; //avoing some reference inexistent like 'All Manga'
                Entities.EntityState state = this.StateCategories[aux];

                string uri = "http://myanimelist.net" + section.Attributes["href"].Value;
                WebImporter requester = new WebImporter();
                string request_html = requester.TryRequest(uri);

                HtmlNode inner_node = HtmlNode.CreateNode(request_html);
                HtmlNodeCollection inner_form = inner_node.SelectNodes(FORM_SEARCH_EXPRESSION);

                Entities.Manga temp;
                foreach (HtmlNode item in inner_form)
                {

                    HtmlNode item_section = item.SelectSingleNode(item.XPath + ELEMENTS_SEARCH_EXPRESSION);
                    if (item_section == null)
                        continue;

                    item_section = item.SelectSingleNode(item.XPath + "//tr");

                    temp = new Entities.Manga();
                    temp.Name = item_section.SelectSingleNode(item_section.XPath + "//span[1]").InnerText;
                    temp.State = state;

                    aux = HNodeHelper.AnalizeNodeValue(item_section, item_section.XPath + "//td[3]", "0");
                    temp.Rating = StringHelper.GetOnlyNumbers(aux);

                    aux = HNodeHelper.AnalizeNodeValue(item_section, item_section.XPath + "//td[4]", "-/-");
                    temp.ProgressString = aux;
                    temp.Category = this.MangaTypeCategories["Manga"];
                    temp.Comment = "";

                    this.Items.Add(temp);
                }
            }
        }
        
    }
}
