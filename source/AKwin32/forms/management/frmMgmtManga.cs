using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Framework.repo.xml;
using Framework.entity;

namespace AKwin32.forms.management
{
    public partial class frmMgmtManga : AKwin32.forms.management.frmManagement, IUIManagement
    {

        List<Manga> dataSource;

        MangaRepository repo;

        public frmMgmtManga()
        {
            InitializeComponent();
            entityType = typeof(Manga);
            repo = new MangaRepository();
        }

        #region GUI Events

        void btnRemoveItem_Click(object sender, EventArgs e)
        {
            Manga manga = listViewItems.SelectedItems[0].Tag as Manga;
            listViewItems.SelectedItems[0].Remove();
            repo.Remove(manga);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            dataSource.Clear();
            foreach (ListViewItem item in listViewItems.Items)
                dataSource.Add(ObjectToType(item.Tag));
            ((IUIManagement)this).SaveItemsToRepository(false);
            //
            this.Close();
        }

        #endregion

        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            dataSource = OriginalDataSource.ConvertAll(
            new Converter<object, Manga>(ObjectToType));
        }

        void IUIManagement.DoVisualChanges()
        {
            btnRemoveItem.Click += new EventHandler(btnRemoveItem_Click);
            btnAccept.Click += new EventHandler(btnAccept_Click);

            cb_Category.DataSource = catalog.GetMangaCategoriesTypes();
            cb_Category.ValueMember = "Id";
            cb_Category.DisplayMember = "Value";
        }

        void IUIManagement.InheritControlSelection(System.Windows.Forms.Control ctrl, string name, object entity)
        {
            System.Reflection.PropertyInfo p;
            Manga manga = entity as Manga;
            if (name == "Episodes")
            {
                p = entity.GetType().GetProperty("Chapters");
                ctrl.Text = manga.ChapterString;
            }
        }

        void IUIManagement.InheritControlValidation(System.Windows.Forms.Control ctrl, System.Reflection.PropertyInfo p, object entity)
        {
            if (p.PropertyType == typeof(MANGA_TYPE))
            {
                MANGA_TYPE s = (MANGA_TYPE)Enum.Parse(typeof(MANGA_TYPE), ctrl.Text);
                p.SetValue(entity, (int)s, null);
            }
        }

        void IUIManagement.LoadDataToControls()
        {
            ListViewItem item;
            foreach (Manga manga in this.dataSource)
            {
                item = new ListViewItem(new string[] { manga.Name, manga.Category + "" });
                item.Tag = manga;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.PrepareDataFromRepo()
        {
            this.dataSource = repo.GetAll().ToList();
        }

        void IUIManagement.FilterData(List<object> list)
        {
            ListViewItem item;
            foreach (Manga manga in list)
            {
                item = new ListViewItem(new string[] { manga.Name, manga.Category + "" });
                item.Tag = manga;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.setReadOnlyMode()
        {
            //throw new NotImplementedException();
        }

        void IUIManagement.SaveItemsToRepository(bool newItems)
        {
            int result;
            if (newItems)
                result = repo.AddRange(dataSource);
            else
                result = repo.Change(dataSource);

            if (result != dataSource.Count)
                base.ShowInformation(this,
                    Program.Language.MessagesLibrary["items_saved"] + String.Format(" ({0})", result));
        }

        #endregion

        #region Functions

        private Manga ObjectToType(object obj)
        {
            return (Manga)obj;
        }

        #endregion

    }
}
