using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;
using System.Xml.Linq;

namespace Framework.repo
{
    public class AnimeRepository : Repository
    {



        public AnimeRepository(String connection)
            : base(connection)
        {
            
        }

        public Anime Add(Anime item)
        {
            XElement element = template;
            element.Element("name").SetValue(item.Nombre);
            element.Element("state").SetValue((int)item.Estado);
            element.Element("episode").SetValue(item.Captiulos);
            element.Element("comment").SetValue(item.Comentario);

            base.AddItem(element);

            return null;
        }

        public List<Anime> GetAll_Queue()
        {
            List<XElement> elements = base.GetAll();
            List<Anime> animes = new List<Anime>();

            Anime temp;
            foreach (XElement item in elements)
            {
                temp = new Anime()
                {
                    Nombre = item.Element("name").Value,
                    Estado = (ANIME_STATE) Convert.ToInt32(item.Element("state").Value),
                    Comentario = item.Element("comment").Value
                };
                temp.Captiulos = Convert.ToInt32(1);
            }

            return animes;
        }

        public List<Anime> GetAll_Watching()
        {
            List<XElement> elements = base.GetAll();
            List<Anime> animes = new List<Anime>();

            Anime temp;
            foreach (XElement item in elements)
            {
                temp = new Anime()
                {
                    Nombre = item.Element("name").Value,
                    Estado = (ANIME_STATE)Convert.ToInt32(item.Element("state").Value),
                    Comentario = item.Element("comment").Value
                };
                temp.Captiulos = Convert.ToInt32(1);
            }

            return animes;
        }

        public List<Anime> GetAll_Watched()
        {
            List<XElement> elements = base.GetAll();
            List<Anime> animes = new List<Anime>();

            Anime temp;
            foreach (XElement item in elements)
            {
                temp = new Anime()
                {
                    Nombre = item.Element("name").Value,
                    Estado = (ANIME_STATE)Convert.ToInt32(item.Element("state").Value),
                    Comentario = item.Element("comment").Value
                };
                temp.Captiulos = Convert.ToInt32(1);
            }

            return animes;
        }

    }
}
