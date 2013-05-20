using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;
using System.Xml.Linq;

namespace Framework.repo.xml
{
    public class UserRepository : Repository<User>
    {

        StringBuilder userTemplate = null;

        public UserRepository()
        {
            userTemplate = new StringBuilder();
            userTemplate.AppendLine("\n\t\t<User id='0' category='1'>");
            userTemplate.AppendLine("\t\t\t<name></name>");
            userTemplate.AppendLine("\t\t</User>\n");
        }

        public override User Add(User item)
        {
            item.Codigo = this.NewItemID;
            XElement temp = this.GetParent();
            XElement user = ToData(item);
            if (temp.Elements().Contains(user)) return null;
            //
            temp.Add(user);
            base.setModifiedState();
            base.Refresh();
            //
            return item;
        }

        public override void Change(User item)
        {
            this.GetParent().Elements().FirstOrDefault(c => c.Attribute("id").Value == item.Codigo + "").ReplaceWith(ToData(item));
            base.setModifiedState();
            base.Refresh();
        }

        public override IList<User> GetAll()
        {
            List<XElement> elements = this.GetParent().Elements("User").ToList();

            List<User> list = new List<User>();

            foreach (XElement item in elements)
            {
                list.Add(ToEntity(item));
            }

            return list;
        }

        public override void Remove(User item)
        {
            this.GetParent().Elements().FirstOrDefault(c => c.Attribute("id").Value == item.Codigo + "").Remove();
            base.setModifiedState();
            base.Refresh();
        }

        public void ReleaseData()
        {
            this.GetParent().Elements().Remove();
            this.setModifiedState();
            this.Refresh();
        }

        public override IList<User> LookUp(string name)
        {
            List<XElement> elements = base.GetAllByType(typeof(User));
            List<User> list = new List<User>();

            foreach (XElement item in elements.Where(c => c.Element("name").Value.ToLower().Contains(name)))
            {
                list.Add(ToEntity(item));
            }
            return list;
        }

        private XElement GetParent()
        {
            return akMainData.Element(io.Configuration.ApplicationName).Element("Users");
        }

        private XElement LoadTemplate()
        {
            return XElement.Parse(userTemplate.ToString(), LoadOptions.PreserveWhitespace);
        }

        internal override User ToEntity(XElement item)
        {
            User temp;
            temp = new User()
            {
                Name = item.Element("name").Value
            };
            temp.Codigo = util.Expression.IfIntegerNull(item.Attribute("id").Value, 0);
            temp.Sources = item.Elements("source").Select(c => c.Value).ToArray();

            return temp;
        }

        internal override XElement ToData(User item)
        {
            XElement element = LoadTemplate();
            element.SetAttributeValue("id", item.Codigo);
            element.Element("name").SetValue(item.Name);
            foreach (string s in item.Sources)
                element.Add(new XText("\t"),
                            new XElement("source", s),
                            new XText("\n\t\t"));

            return element;

        }

    }
}
