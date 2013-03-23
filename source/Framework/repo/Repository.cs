using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;
using System.Xml.Linq;
using Framework.io;

namespace Framework.repo
{
    public abstract class Repository//<T> where T : class, new()
    {

        private String connection;

        private XDocument dataContext;

        public Repository(String connection)
        {
            this.connection = io.Configuration.Rsource + connection;
            dataContext = XDocument.Load(this.connection);
            //
            StringBuilder temp = new StringBuilder();
            temp.AppendLine("<Anime id=''>");
            temp.AppendLine("   <name></name>");
            temp.AppendLine("   <state></state>");
            temp.AppendLine("   <episode></episode>");
            temp.AppendLine("   <comment></comment>");
            temp.AppendLine("</Anime>");

            template = XElement.Parse(temp.ToString(), LoadOptions.PreserveWhitespace);
        }


        protected XElement AddItem(XElement item)
        {
            
            template.Attribute("id").SetValue(this.GetNewId());
            this.GetParent().Add(template);
            Update();

            return null;
        }

        protected XElement Change(XElement item)
        {

            return null;
        }

        protected List<XElement> GetAll()
        {
            return dataContext.Element(Configuration.AppName).Element("Animes").Elements("Anime").ToList();
        }

        protected List<XElement> GetAllByType(ANIME_STATE type)
        {
            return dataContext.Element(Configuration.AppName).Element("Animes").Elements("Anime").Where( c=> c.Element("state").Value == ((int)type)+"" ).ToList();
        }

        protected XElement GetByID(string id)
        {
            return GetAll().Where(c => c.Attribute("id").Value == id).FirstOrDefault();
        }

        private XElement GetParent()
        {
            return dataContext.Element(Configuration.AppName).Element("Animes");
        }

        private int GetNewId()
        {
            int id           = 0;
            XElement element = dataContext.Element(Configuration.AppName).Element("Animes").Elements("Anime").LastOrDefault();
            if (element != null)
            {
                string aux = element.Attribute("id").Value;
                id = String.IsNullOrEmpty(aux) ? 0 : Convert.ToInt32(aux);
                id++;
            }
            return id;
        }

        protected XElement template;

        private void Update()
        {            
            dataContext.Save(this.connection, SaveOptions.None);
        }

    }
}
