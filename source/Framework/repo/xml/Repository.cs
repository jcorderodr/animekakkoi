using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.entity;
using System.Xml.Linq;
using Framework.io;

namespace Framework.repo.xml
{
    /// <summary>
    /// 
    /// @version 0.2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IDisposable where T : class, new()
    {

        protected internal XElement animeTemplate;
        protected internal XElement mangaTemplate;

        /// <summary>
        /// Object used to store in memory all the availables resources/repositories for saving data.
        /// </summary>
        Dictionary<ENTITY_STATE, XDocument> documentsContext;

        private XDocument dataContext;

        internal XDocument akMainData;

        XElement propertiesElement;

        private String connection;

        private int newId;

        private bool isDataModified = false;


        #region Constructors/Destructor

        public Repository()
        {
            //
            documentsContext = new Dictionary<ENTITY_STATE, XDocument>();
            documentsContext.Add(ENTITY_STATE.QUEUE, XDocument.Load(io.Configuration.ApplicationDataFolder
                + io.Configuration.GetAkFile(ENTITY_STATE.QUEUE)));
            documentsContext.Add(ENTITY_STATE.TAKED_DOWN, XDocument.Load(io.Configuration.ApplicationDataFolder
                + io.Configuration.GetAkFile(ENTITY_STATE.TAKED_DOWN)));
            documentsContext.Add(ENTITY_STATE.WANT_TO, XDocument.Load(io.Configuration.ApplicationDataFolder
                + io.Configuration.GetAkFile(ENTITY_STATE.WANT_TO)));
            documentsContext.Add(ENTITY_STATE.WATCHED, XDocument.Load(io.Configuration.ApplicationDataFolder
                + io.Configuration.GetAkFile(ENTITY_STATE.WATCHED)));
            documentsContext.Add(ENTITY_STATE.WATCHING, XDocument.Load(io.Configuration.ApplicationDataFolder
                + io.Configuration.GetAkFile(ENTITY_STATE.WATCHING)));
            //
            InitComponents();
        }

        [Obsolete]
        public Repository(String connection)
        {
            this.connection = io.Configuration.ApplicationDataFolder + connection;
            dataContext = XDocument.Load(this.connection);
            //
            InitComponents();
        }

        ~Repository()
        {
            //Update();

            this.Dispose();
        }

        #endregion

        #region Public Functions

        public void Dispose()
        {
            if (propertiesElement != null)
            {

            }
            //
            akMainData = null;
            documentsContext = null;
            dataContext = null;
        }

        #endregion

        #region Protected Functions

        protected internal XElement AddItem(XElement item, ENTITY_STATE section)
        {
            if (ItemExist(item, section) != null) return null;

            item.Attribute("id").SetValue(this.NewItemID);
            this.GetParent(section).Add(item);
            isDataModified = true;

            return item;
        }

        protected internal XElement ChangeItem(XElement item)
        {
            string id = item.Attribute("id").Value;
            try
            {
                this.GetItemByID(item.Name.ToString(), id).ReplaceWith(item);
                isDataModified = true;
            }
            catch (NullReferenceException) { return null; }
            return item;
        }

        protected internal List<XElement> GetAllByType(Type type)
        {
            List<XElement> list = new List<XElement>();
            foreach (XDocument doc in documentsContext.Values)
            {
                list.AddRange(doc.Elements(io.Configuration.ApplicationName).Elements(type.Name).ToList());
            }
            return list;
        }

        protected internal XElement GetItemByID(string name, string id)
        {
            XElement element;
            foreach (XDocument doc in documentsContext.Values)
            {
                element = doc.Elements(io.Configuration.ApplicationName).Elements(name).FirstOrDefault(c => c.Attribute("id").Value == id);
                if (element != null) return element;
            }
            return null;
        }

        protected internal int NewItemID
        {
            get
            {
                return ++newId;
            }
        }

        protected internal void Refresh()
        {
            if (isDataModified)
            {
                this.Update();
                isDataModified = false;
            }
        }

        protected internal void Remove(XElement item, ENTITY_STATE section)
        {
            string id = item.Attribute("id").Value;
            XElement element = this.GetParent(section).Elements(item.Name.ToString()).FirstOrDefault(c => c.Attribute("id").Value == id);
            if (element == null) return;
            element.Remove();
            this.Update();
        }

        protected internal void setModifiedState()
        {
            isDataModified = true;
        }

        protected internal void setModifiedState(bool isModified)
        {
            isDataModified = isModified;
        }

        #endregion

        #region Private Functions

        private void InitComponents()
        {
            string path = io.Configuration.ApplicationDataFolder + io.Configuration.RS_CENTRAL;
            akMainData = XDocument.Load(path, LoadOptions.PreserveWhitespace);
            //
            //
            //
            LoadTemplates();
            //
            //  MAIN_DATA_PROPERTIES_SECTION : Section with main properties and values.
            //
            newId = 0;
            propertiesElement = akMainData.Element(Configuration.ApplicationName).Elements(io.Configuration.MAIN_DATA_PROPERTIES_SECTION).FirstOrDefault();
            if (propertiesElement != null)
            {
                string aux = propertiesElement.Attribute("max_id").Value;
                newId = String.IsNullOrEmpty(aux) ? 1 : Convert.ToInt32(aux);
            }
        }

        private void LoadTemplates()
        {
            StringBuilder temp = new StringBuilder();
            temp.AppendLine("\n<Anime id='0' category='1' fav='0'>");
            temp.AppendLine("   <name></name>");
            temp.AppendLine("   <state></state>");
            temp.AppendLine("   <episode></episode>");
            temp.AppendLine("   <rate></rate>");
            temp.AppendLine("   <comment></comment>");
            temp.AppendLine("</Anime>\n");
            animeTemplate = XElement.Parse(temp.ToString(), LoadOptions.PreserveWhitespace);

            temp = new StringBuilder();
            temp.AppendLine("\n<Manga id='0' category='1' fav='0'>");
            temp.AppendLine("   <name></name>");
            temp.AppendLine("   <state></state>");
            temp.AppendLine("   <episode></episode>");
            temp.AppendLine("   <rate></rate>");
            temp.AppendLine("   <comment></comment>");
            temp.AppendLine("</Manga>\n");
            mangaTemplate = XElement.Parse(temp.ToString(), LoadOptions.PreserveWhitespace);
        }

        private XElement GetParent(ENTITY_STATE section)
        {
            return documentsContext[section].Element(Configuration.ApplicationName);
        }

        private XElement ItemExist(XElement item, ENTITY_STATE section)
        {
            //TODO: check out this performance
            // for his resource's type, the first ocurrency of his name & category 
            XElement aux = this.GetParent(section).Elements(item.Name)
                .FirstOrDefault(c => c.Element("name").Value == item.Element("name").Value &&
                                c.Attribute("category").Value == item.Attribute("category").Value);
            return aux;
        }

        private void Update()
        {
            if (documentsContext != null)
            {
                Dictionary<ENTITY_STATE, XDocument>.Enumerator i = documentsContext.GetEnumerator();
                while (i.MoveNext())
                {
                    i.Current.Value.Save(io.Configuration.ApplicationDataFolder
                        + io.Configuration.GetAkFile(i.Current.Key), SaveOptions.None);
                }
                propertiesElement.Attribute("max_id").SetValue(newId);
                akMainData.Save(io.Configuration.ApplicationDataFolder + io.Configuration.RS_CENTRAL, SaveOptions.None);
            }
            else
            {
                dataContext.Save(this.connection, SaveOptions.DisableFormatting);
            }
        }

        #endregion

        #region Inherit

        public abstract T Add(T item);

        public abstract int AddRange(IList<T> items);

        public abstract void Change(T item);

        public abstract void Remove(T item);

        public abstract IList<T> GetAll();

        internal abstract T ToEntity(XElement item);

        internal abstract XElement ToData(T item);

        #endregion



    }
}
