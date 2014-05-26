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
    public partial class frmMgmtAnime : AnimeKakkoi.App.forms.management.frmManagement, IUIManagement
    {
        private AnimeRepository repo;

        private List<Anime> dataSource;

        public frmMgmtAnime()
        {
            InitializeComponent();
            this.Text = "Anime";
            entityType = typeof (Anime);
            repo = new AnimeRepository();
        }

        #region GUI Events

        protected override void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count < 1) return;
            var anime = listViewItems.SelectedItems[0].Tag as Anime;
            listViewItems.SelectedItems[0].Remove();
            repo.Remove(anime);

            string evt_change = " (-) " + anime;
            EventLogger.Write(AnimeKakkoi.App.IO.AppAkConfiguration.ApplicationLoggerFile, evt_change);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //
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
            this.dataSource = OriginalDataSource.ConvertAll(
                ObjectToType);
        }

        void IUIManagement.DoVisualChanges()
        {
            btnRemoveItem.Click += btnRemoveItem_Click;
            btnAccept.Click += btnAccept_Click;

            base.FillComboBoxCatalog(cb_Category, Catalog.GetAnimeCategoriesTypes());
        }

        void IUIManagement.InheritControlSelection(System.Windows.Forms.Control ctrl, string pName, object entity)
        {
        }

        void IUIManagement.InheritControlValidation(Control ctrl, System.Reflection.PropertyInfo p, object entity)
        {
            if (p.PropertyType == typeof (ANIME_TYPE))
            {
                var s = (ANIME_TYPE) Enum.Parse(typeof (ANIME_TYPE), ctrl.Text);
                p.SetValue(entity, (int) s, null);
            }
        }

        void IUIManagement.LoadDataToControls()
        {
            ListViewItem item;
            foreach (Anime anime in this.dataSource)
            {
                item = new ListViewItem(new[] {anime.Name, anime.ToString()});
                item.Tag = anime;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.PrepareDataFromRepo()
        {
            this.dataSource = repo.GetAll().ToList();
            OriginalDataSource = dataSource.ConvertAll(
                TypeToObject);
        }

        void IUIManagement.FilterData(List<object> list)
        {
            ListViewItem item;
            foreach (Anime anime in list)
            {
                item = new ListViewItem(new[] {anime.Name, anime.ToString()});
                item.Tag = anime;
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

            base.ShowInformation(this,
                                 base.Messages["items_saved"] + String.Format(" ({0})", result));
        }

        #endregion

        #region Functions

        private Anime ObjectToType(object obj)
        {
            return (Anime) obj;
        }

        private object TypeToObject(Anime item)
        {
            return item;
        }

        #endregion
    }
}