using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.App.Helpers;
using AnimeKakkoi.Core.Data;
using AnimeKakkoi.Core.Data.Json;
using AnimeKakkoi.Core.Entities;

namespace AnimeKakkoi.App.Forms.Management
{
    public partial class FrmMgmtManga : FrmManagement, IUIManagement
    {
        private IList<Manga> _dataSource;

        private readonly IMangaRepository _repo;

        public FrmMgmtManga()
        {
            InitializeComponent();
            EntityType = typeof (Manga);
            _repo = new MangaRepository();
        }

        #region UI Events

        protected override void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count < 1) return;

            var manga = listViewItems.SelectedItems[0].Tag as Manga;
            listViewItems.SelectedItems[0].Remove();
            _repo.Remove(manga);

            var evtChange = " (-) " + manga;
            //EventLogger.Write(IO.AppAkConfiguration.AppLoggerFile, evtChange);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _dataSource.Clear();
            foreach (ListViewItem item in listViewItems.Items)
                _dataSource.Add(item.Tag as Manga);
            ((IUIManagement) this).SaveItemsToRepository(false);
            //
            this.Close();
        }

        #endregion

        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            _dataSource = OriginalDataSource.Select(obj => obj as Manga).ToList();
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
            if (p.PropertyType == typeof (MangaType))
            {
                var s = (MangaType)Enum.Parse(typeof(MangaType), ctrl.Text);
                p.SetValue(entity, (int) s, null);
            }
        }

        void IUIManagement.LoadDataToControls()
        {
            ListViewItem item;
            foreach (Manga manga in this._dataSource)
            {
                item = new ListViewItem(new[] {manga.Name, manga.ToString()});
                item.Tag = manga;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.PrepareDataFromRepo()
        {
            this._dataSource = _repo.GetAll().ToList();
        }

        void IUIManagement.FilterData(IEnumerable<object> list)
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
                result = _repo.AddRange(_dataSource);
            else
                result = _repo.Change(_dataSource);

            if (result != _dataSource.Count)
                AnimeKakkoi.App.Helpers.MessageHandler.ShowInformation(this,
                                     base.Messages["items_saved"] + String.Format(" ({0})", result));
        }

        #endregion




        public void ShowItem<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}