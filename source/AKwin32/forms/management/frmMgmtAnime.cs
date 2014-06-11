using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.App.Helpers;
using AnimeKakkoi.Core.Data.Json;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.Data;
using AnimeKakkoi.Core.Helpers;

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
            EntityType = typeof(Anime);
            _repo = new AnimeRepository();
        }

        #region GUI Events

        protected override void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count < 1) return;
            var anime = listViewItems.SelectedItems[0].Tag as Anime;
            listViewItems.SelectedItems[0].Remove();
            _repo.Remove(anime);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _dataSource.Clear();
            foreach (ListViewItem item in listViewItems.Items)
                _dataSource.Add(item.Tag as Anime);
            ((IUIManagement)this).SaveItemsToRepository(false);
            //
            this.Close();
        }

        #endregion

        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            this._dataSource = OriginalDataSource.Select(obj => obj as Anime).ToList();
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
            if (p.PropertyType == typeof(AnimeType))
            {
                var s = (AnimeType)Enum.Parse(typeof(AnimeType), ctrl.Text);
                p.SetValue(entity, (int)s, null);
            }
        }

        void IUIManagement.LoadDataToControls()
        {
            foreach (Anime anime in this._dataSource)
            {
                ListViewItem item = new ListViewItem(new[] { anime.Name, anime.ToString() });
                item.Tag = anime;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.PrepareDataFromRepo()
        {
            this._dataSource = _repo.GetAll().ToList();
            OriginalDataSource = _dataSource.Select(obj => obj as Anime).ToList();
        }

        void IUIManagement.FilterData(IEnumerable<object> list)
        {
            foreach (Anime anime in list)
            {
                ListViewItem item = new ListViewItem(new[] { anime.Name, anime.ToString() });
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

            AnimeKakkoi.App.Helpers.MessageHandler.ShowInformation(this,
                                 base.Messages["items_saved"] + String.Format(" ({0})", result));
        }

        #endregion

        public void ShowItem<T>(T item)
        {
            var value = item as Core.Entities.Anime;

            AlternateFavoriteControl(value.Favorite);

            txt_Name.Text = value.Name;
            txt_Rating.Text = value.Rating + "";
            txt_Comment.Text = value.Comment;
            txt_Progress.Text = value.ProgressString;

            cb_Category.SelectedText = value.Category + "";
            cb_State.SelectedText = value.State.ToString();
        }

    }

}