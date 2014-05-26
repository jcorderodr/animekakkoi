using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimeKakkoi.Framework.Entities;
using AnimeKakkoi.Framework.IO;
using System.Xml.Linq;
using AnimeKakkoi.Framework.repo;

namespace AnimeKakkoi.Framework.Repo.xml
{
    /// <summary>
    /// 
    /// @version 0.2
    /// </summary>
    /// <typeparam name="T">Framework.entity.EntitySource</typeparam>
    public abstract class Repository<T> : IRepository<T>, IDisposable where T : class, new()
    {

        private  StringBuilder animeTemplate;
        private StringBuilder mangaTemplate;

        /// <summary>
        /// Object used to store in memory all the availables resources/repositories for saving data.
        /// </summary>
        Dictionary<EntityState, XDocument> documentsContext;

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
            documentsContext = new Dictionary<EntityState, XDocument>();

            //var qLoad = XDocument.Load(AkConfiguration.ApplicationDataFolder
            //                           + AkConfiguration.GetAkFile(EntityState.Queue));
            //documentsContext.Add(EntityState.Queue, qLoad);

            documentsContext.Add(EntityState.TakedDown, XDocument.Load(AkConfiguration.ApplicationDataFolder
                + AkConfiguration.GetAkFile(EntityState.TakedDown)));

            documentsContext.Add(EntityState.WantTo, XDocument.Load(AkConfiguration.ApplicationDataFolder
                + AkConfiguration.GetAkFile(EntityState.WantTo)));

            documentsContext.Add(EntityState.Watched, XDocument.Load(AkConfiguration.ApplicationDataFolder
                + AkConfiguration.GetAkFile(EntityState.Watched)));

            documentsContext.Add(EntityState.Watching, XDocument.Load(AkConfiguration.ApplicationDataFolder
                + AkConfiguration.GetAkFile(EntityState.Watching)));
            //
            InitComponents();
        }

        [Obsolete]
        public Repository(String connection)
        {
            this.connection = AkConfiguration.ApplicationDataFolder + connection;
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
            //if (propertiesElement != null)
            //{

            //}
            //
            akMainData = null;
            documentsContext = null;
            dataContext = null;
        }

        #endregion

        #region Protected Functions

        protected internal XElement AddItem(XElement item, EntityState section)
        {
            if (ItemExist(item, section) != null)
                return null;

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

        protected internal void DisposeItems()
        {
            foreach (XDocument doc in documentsContext.Values)
            {
                doc.Elements(AkConfiguration.APPLICATION_NAME).Elements(RepositoryType().Name).Remove();
            }
            this.Update();
        }

        protected internal List<XElement> GetAllByType(Type type)
        {
            List<XElement> list = new List<XElement>();
            foreach (XDocument doc in documentsContext.Values)
            {
                list.AddRange(doc.Elements(AkConfiguration.APPLICATION_NAME).Elements(type.Name).ToList());
            }
            return list;
        }

        protected internal XElement GetItemByID(string name, string id)
        {
            XElement element;
            foreach (XDocument doc in documentsContext.Values)
            {
                element = doc.Elements(AkConfiguration.APPLICATION_NAME).Elements(name).FirstOrDefault(c => c.Attribute("id").Value == id);
                if (element != null) return element;
            }
            return null;
        }

        protected internal XElement getAnimeTemplate()
        {
            return XElement.Parse(animeTemplate.ToString(), LoadOptions.PreserveWhitespace);
        }

        protected internal XElement getMangaTemplate()
        {
            return XElement.Parse(mangaTemplate.ToString(), LoadOptions.PreserveWhitespace);
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

        protected internal void Remove(XElement item, EntityState section)
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
            string path = AkConfiguration.ApplicationDataFolder + AkConfiguration.RS_CENTRAL;
            akMainData = XDocument.Load(path, LoadOptions.PreserveWhitespace);
            LoadTemplates();
            //
            //  MAIN_DATA_PROPERTIES_SECTION : Section with main properties and values.
            //
            newId = 0;
            propertiesElement = akMainData.Element(AkConfiguration.APPLICATION_NAME).Elements(AkConfiguration.PROPERTIES_SECTION_MAIN_DATA).FirstOrDefault();
            if (propertiesElement != null)
            {
                string aux = propertiesElement.Attribute("max_id").Value;
                newId = String.IsNullOrEmpty(aux) ? 1 : Convert.ToInt32(aux);
            }
        }

        private XElement GetParent(EntityState section)
        {
            return documentsContext[section].Element(AkConfiguration.APPLICATION_NAME);
        }

        private XElement ItemExist(XElement item, EntityState section)
        {
            XElement aux = this.GetParent(section).Elements(item.Name)
                .FirstOrDefault(c => c.Element("name").Value == item.Element("name").Value &&
                                c.Attribute("category").Value == item.Attribute("category").Value);
            return aux;
        }

        private void LoadTemplates()
        {
            animeTemplate = new StringBuilder();
            animeTemplate.AppendLine("\n<Anime id='0' category='1' fav='0'>");
            animeTemplate.AppendLine("   <name></name>");
            animeTemplate.AppendLine("   <state></state>");
            animeTemplate.AppendLine("   <episode></episode>");
            animeTemplate.AppendLine("   <rate></rate>");
            animeTemplate.AppendLine("   <comment></comment>");
            animeTemplate.AppendLine("</Anime>\n");

            mangaTemplate = new StringBuilder();
            mangaTemplate.AppendLine("\n<Manga id='0' category='1' fav='0'>");
            mangaTemplate.AppendLine("   <name></name>");
            mangaTemplate.AppendLine("   <state></state>");
            mangaTemplate.AppendLine("   <episode></episode>");
            mangaTemplate.AppendLine("   <rate></rate>");
            mangaTemplate.AppendLine("   <comment></comment>");
            mangaTemplate.AppendLine("</Manga>\n");
        }

        private void Update()
        {
            if (documentsContext != null)
            {
                System.Security.Permissions.FileIOPermission filePermissions =
                new System.Security.Permissions.FileIOPermission(System.Security.Permissions.PermissionState.Unrestricted);
                filePermissions.AddPathList(System.Security.Permissions.FileIOPermissionAccess.Write,
                AkConfiguration.ApplicationDataFolder);
                filePermissions.Demand();

                Dictionary<EntityState, XDocument>.Enumerator i = documentsContext.GetEnumerator();
                while (i.MoveNext())
                {
                    i.Current.Value.Save(AkConfiguration.ApplicationDataFolder
                        + AkConfiguration.GetAkFile(i.Current.Key), SaveOptions.None);
                }
                propertiesElement.Attribute("max_id").SetValue(newId);
                akMainData.Save(AkConfiguration.ApplicationDataFolder + AkConfiguration.RS_CENTRAL, SaveOptions.None);
            }
            else
            {
                dataContext.Save(this.connection, SaveOptions.DisableFormatting);
            }
        }

        #endregion

        #region Inherit

        public abstract T Add(T item);

        public abstract void Change(T item);

        public abstract void Remove(T item);

        public abstract IList<T> GetAll();

        public abstract IList<T> LookUp(string name);

        //--public abstract IList<Anime> LookUp(Func<Anime, bool> predicate);

        public Type RepositoryType()
        {
            return typeof(T);
        }

        internal abstract T ToEntity(XElement item);

        internal abstract XElement ToData(T item);

        #endregion


    }
}
