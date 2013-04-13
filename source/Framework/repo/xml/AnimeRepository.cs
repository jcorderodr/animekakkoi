using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;
using System.Xml.Linq;

namespace Framework.repo.xml
{
    public class AnimeRepository : Repository<Anime>
    {

        public AnimeRepository()
        {

        }

        public override Anime Add(Anime item)
        {
            base.AddItem(ToData(item), item.State);
            base.Refresh();
            return item;
        }

        public override int AddRange(IList<Anime> elements)
        {
            int count = 0;
            foreach (Anime item in elements)
            {
                //if null, then error or exists
                if (base.AddItem(ToData(item), item.State) != null)
                    count++;
            }
            base.Refresh();
            return count;
        }

        public override void Change(Anime item)
        {
            base.ChangeItem(ToData(item));
            base.Refresh();
            //return null;
        }

        public int Change(IList<Anime> elements)
        {
            int count = 0;
            foreach (Anime item in elements)
            {
                base.ChangeItem(ToData(item));
                count++;
            }
            base.Refresh();
            return count;
        }

        public override IList<Anime> GetAll()
        {
            List<XElement> elements = base.GetAllByType(typeof(Anime));

            List<Anime> animes = new List<Anime>();

            foreach (XElement item in elements)
            {
                animes.Add(ToEntity(item));
            }

            return animes;
        }

        public override void Remove(Anime item)
        {
            base.Remove(ToData(item), item.State);
        }


        internal override Anime ToEntity(XElement item)
        {
            Anime temp;
            temp = new Anime()
            {
                Name = item.Element("name").Value,
                Category = (ANIME_TYPE)util.Expression.IfNull(item.Attribute("category").Value, 1),
                State = (ENTITY_STATE)util.Expression.IfNull(item.Element("state").Value, 0),
                Comment = item.Element("comment").Value
            };
            temp.Codigo = util.Expression.IfNull(item.Attribute("id").Value, 0);
            temp.Favorite = Convert.ToBoolean(item.Attribute("fav").Value);
            temp.Episodes = Convert.ToInt32(item.Element("episode").Value);
            temp.Rating = Convert.ToInt32(item.Element("rate").Value);
            return temp;
        }

        internal override XElement ToData(Anime item)
        {
            XElement element = animeTemplate;
            element.SetAttributeValue("id", item.Codigo);
            element.SetAttributeValue("category", (int)item.Category);
            element.SetAttributeValue("fav", item.Favorite);
            element.Element("name").SetValue(item.Name);
            element.Element("state").SetValue((int)item.State);
            element.Element("rate").SetValue(item.Rating);
            element.Element("episode").SetValue(item.Episodes);
            element.Element("comment").SetValue(item.Comment);

            return element;

        }

    }
}
