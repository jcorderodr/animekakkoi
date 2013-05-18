using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;
using System.Xml.Linq;

namespace Framework.repo.xml
{
    public class MangaRepository : Repository<Manga>
    {

        public override Manga Add(Manga item)
        {
            base.AddItem(ToData(item), item.State);
            base.Refresh();
            return item;
        }

        public int AddRange(IList<Manga> items)
        {
            int count = 0;
            foreach (Manga item in items)
            {
                //if null, then error or exists
                if (base.AddItem(ToData(item), item.State) != null)
                    count++;
            }
            base.Refresh();
            return count;
        }

        public override void Change(Manga item)
        {
            base.ChangeItem(ToData(item));
            base.Refresh();
        }

        public int Change(IList<Manga> elements)
        {
            int count = 0;
            foreach (Manga item in elements)
            {
                base.ChangeItem(ToData(item));
                count++;
            }
            base.Refresh();
            return count;
        }

        public override IList<Manga> GetAll()
        {
            List<XElement> elements = base.GetAllByType(typeof(Manga));

            List<Manga> list = new List<Manga>();

            foreach (XElement item in elements)
            {
                list.Add(ToEntity(item));
            }

            return list;
        }
        
        public override IList<Manga> LookUp(string name)
        {
            List<XElement> elements = base.GetAllByType(typeof(Manga));

            List<Manga> list = new List<Manga>();

            foreach (XElement item in elements.Where(c => c.Element("name").Value.ToLower().Contains(name)))
            {
                list.Add(ToEntity(item));
            }

            return list;
        }

        public override void Remove(Manga item)
        {
            try
            {
                this.GetItemByID("Manga", item.Codigo + "").Remove();
                base.setModifiedState();
            }
            catch { }
        }

        public bool RemoveAll()
        {
            try
            {
                base.DisposeItems();
                return true;
            }
            catch { return false; }
        }

        internal override Manga ToEntity(XElement item)
        {
            Manga temp;
            temp = new Manga()
            {
                Name = item.Element("name").Value,
                Category = (MANGA_TYPE)util.Expression.IntegerIfNull(item.Attribute("category").Value, 1),
                State = (ENTITY_STATE)util.Expression.IntegerIfNull(item.Element("state").Value, 0),
                Comment = item.Element("comment").Value
            };
            temp.ProgressString = item.Element("episode").Value;
            temp.Codigo = util.Expression.IntegerIfNull(item.Attribute("id").Value, 0);
            temp.Favorite = Convert.ToBoolean(item.Attribute("fav").Value);

            temp.Rating = Convert.ToInt32(item.Element("rate").Value);
            return temp;
        }

        internal override XElement ToData(Manga item)
        {
            XElement element = getMangaTemplate();
            element.SetAttributeValue("id", item.Codigo);
            element.SetAttributeValue("category", (int)item.Category);
            element.SetAttributeValue("fav", item.Favorite);
            element.Element("episode").SetValue(item.ProgressString);
            element.Element("name").SetValue(item.Name);
            element.Element("state").SetValue((int)item.State);
            element.Element("rate").SetValue(item.Rating);
            element.Element("comment").SetValue(item.Comment);

            return element;

        }


    }
}
