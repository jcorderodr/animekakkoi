using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.App.Helpers;
using AnimeKakkoi.Core.Data.Json;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.Data;

namespace AnimeKakkoi.App.Forms.Management
{
    public partial class FrmMgmtAnime : FrmManagement, IUIManagement
    {
        private readonly IAnimeRepository _repo;

        private IList<Anime> _dataSource;

        public FrmMgmtAnime()
        {
            InitializeComponent();
            this.Text = "Anime";
            EntityType = typeof (Anime);
            _repo = new AnimeRepository();
        }

        #region GUI Events

        protected override void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count < 1) return;
            var anime = listViewItems.SelectedItems[0].Tag as Anime;
            listViewItems.SelectedItems[0].Remove();
            _repo.Remove(anime);

            var evtChange = " (-) " + anime;
            EventLogger.Write(AnimeKakkoi.App.IO.AppAkConfiguration.ApplicationLoggerFile, evtChange);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //
            _dataSource.Clear();
            foreach (ListViewItem item in listViewItems.Items)
                _dataSource.Add(ObjectToType(item.Tag));
            ((IUIManagement) this).SaveItemsToRepository(false);
            //
            this.Close();
        }

        #endregion

        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            this._dataSource = OriginalDataSource.ConvertAll(
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
            if (p.PropertyType == typeof (AnimeType))
            {
                var s = (AnimeType)Enum.Parse(typeof(AnimeType), ctrl.Text);
                p.SetValue(entity, (int) s, null);
            }
        }

        void IUIManagement.LoadDataToControls()
        {
            foreach (Anime anime in this._dataSource)
            {
                ListViewItem item = new ListViewItem(new[] {anime.Name, anime.ToString()});
                item.Tag = anime;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.PrepareDataFromRepo()
        {
            this._dataSource = _repo.GetAll().ToList();
            OriginalDataSource = _dataSource.ConvertAll(
                TypeToObject);
        }

        void IUIManagement.FilterData(List<object> list)
        {
            foreach (Anime anime in list)
            {
                ListViewItem item = new ListViewItem(new[] {anime.Name, anime.ToString()});
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
            result = newItems ? _repo.AddRange(_dataSource) : _repo.Change(_dataSource);

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