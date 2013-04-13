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

        XElement userTemplate;

        public UserRepository()
        {
            StringBuilder temp = new StringBuilder();
            temp.AppendLine("\n\t\t<User id='0' category='1'>");
            temp.AppendLine("\t\t\t<name></name>");
            temp.AppendLine("\t\t</User>\n");
            userTemplate = XElement.Parse(temp.ToString(), LoadOptions.PreserveWhitespace);
        }

        public override User Add(User item)
        {
            this.GetParent().Add(ToData(item));
            base.setModifiedState();
            base.Refresh();
            return item;
        }

        [Obsolete("NotImplementedException", true)]
        public override int AddRange(IList<User> items)
        {
            throw new NotImplementedException();
        }

        public override void Change(User item)
        {
            this.GetParent().Elements().FirstOrDefault(c => c.Attribute("id").Value == item.Codigo+"").ReplaceWith( ToData(item));
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
            throw new NotImplementedException();
        }

        private XElement GetParent()
        {
            return akMainData.Element(io.Configuration.ApplicationName).Element("Users");
        }

        internal override User ToEntity(XElement item)
        {
            User temp;
            temp = new User()
            {
                Name = item.Element("name").Value
            };
            temp.Codigo = util.Expression.IfNull(item.Attribute("id").Value, 0);
            temp.Sources = item.Elements("source").Select(c => c.Value).ToArray();

            return temp;
        }

        internal override XElement ToData(User item)
        {
            XElement element = userTemplate;
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
