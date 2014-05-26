#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms.Management;
using AnimeKakkoi.App.Helpers;
using AnimeKakkoi.Framework.Entities;
using AnimeKakkoi.Framework.IO;
using AnimeKakkoi.Framework.Repo.xml;

#endregion

namespace AnimeKakkoi.App.forms.management
{
    public partial class frmMgmtManga : AnimeKakkoi.App.forms.management.frmManagement, IUIManagement
    {
        private List<Manga> dataSource;

        private MangaRepository repo;

        public frmMgmtManga()
        {
            InitializeComponent();
            entityType = typeof (Manga);
            repo = new MangaRepository();
        }

        #region GUI Events

        protected override void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count < 1) return;
            var manga = listViewItems.SelectedItems[0].Tag as Manga;
            listViewItems.SelectedItems[0].Remove();
            repo.Remove(manga);

            string evt_change = " (-) " + manga;
            EventLogger.Write(AnimeKakkoi.App.IO.AppAkConfiguration.ApplicationLoggerFile, evt_change);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            dataSource.Clear();
            foreach (ListViewItem item in listViewItems.Items)
                dataSource.Add(ObjectToType(item.Tag));
            ((IUIManagement) this).SaveItemsToRepository(false);
            //
            this.Close();
        }

        #endregion

        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            dataSource = OriginalDataSource.ConvertAll(
                ObjectToType);
        }

        void IUIManagement.DoVisualChanges()
        {
            btnRemoveItem.Click += btnRemoveItem_Click;
            btnAccept.Click += btnAccept_Click;

            cb_Category.DataSource = Catalog.GetMangaCategoriesTypes();
            cb_Category.ValueMember = "Id";
            cb_Category.DisplayMember = "Value";
        }

        void IUIManagement.InheritControlSelection(System.Windows.Forms.Control ctrl, string name, object entity)
        {
            //this must not happen. It's here just in case.
            System.Reflection.PropertyInfo p;
            var manga = entity as Manga;
            if (name == "Episodes")
            {
                p = entity.GetType().GetProperty("Chapters");
                ctrl.Text = manga.ProgressString;
            }
        }

        void IUIManagement.InheritControlValidation(System.Windows.Forms.Control ctrl, System.Reflection.PropertyInfo p,
                                                    object entity)
        {
            if (p.PropertyType == typeof (MANGA_TYPE))
            {
                var s = (MANGA_TYPE) Enum.Parse(typeof (MANGA_TYPE), ctrl.Text);
                p.SetValue(entity, (int) s, null);
            }
        }

        void IUIManagement.LoadDataToControls()
        {
            ListViewItem item;
            foreach (Manga manga in this.dataSource)
            {
                item = new ListViewItem(new[] {manga.Name, manga.ToString()});
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
                item = new ListViewItem(new[] {manga.Name, manga.ToString()});
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
                                     base.Messages["items_saved"] + String.Format(" ({0})", result));
        }

        #endregion

        #region Functions

        private Manga ObjectToType(object obj)
        {
            return (Manga) obj;
        }

        #endregion
    }
}