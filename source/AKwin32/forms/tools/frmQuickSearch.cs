using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.Core.Data;
using AnimeKakkoi.Core.Data.Json;
using AnimeKakkoi.Core.Entities;


namespace AnimeKakkoi.App.Forms.tools
{
    public partial class frmQuickSearch : BaseToolbox
    {
        private readonly IAnimeRepository _animeRepo;
        private IMangaRepository mangaRepo;

        private string _searchCriteria;

        public frmQuickSearch()
        {
            InitializeComponent();
            _animeRepo = new AnimeRepository();
            //mangaRepo = new MangaRepository();
        }

        private void frmQuickSearch_Load(object sender, EventArgs e)
        {
            this.listViewItems.Resize += listViewItems_Resize;
        }

        private void txtSearchCriteria_TextChanged(object sender, EventArgs e)
        {
            if (AnimeKakkoi.App.IO.AppAkConfiguration.UserUsingInstantSearch)
                DoSearch();
        }

        private void txtSearchCriteria_Validated(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = listViewItems.SelectedItems[0];
            if (item == null) return;

            var frm = new Management.frmEntityEdit();
            frm.SetEntityObject(item.Tag);
            if (item.Tag.GetType() == typeof (Anime))
                frm.SetRepository(_animeRepo);
            else
            {
                AnimeKakkoi.App.Helpers.MessageHandler.ShowError(this, base.Errors["entity_missed"]);
                return;
            }

            frm.Show();
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Functions

        private void DoSearch()
        {
            _searchCriteria = txtSearchCriteria.Text;
            ValidateInput();
        }

        private void ValidateInput()
        {
            if (String.IsNullOrEmpty(_searchCriteria.Trim())) return;

            listViewItems.Items.Clear();
            LoadDataToControls_Anime(_animeRepo.LookUp(_searchCriteria));
            LoadDataToControls_Manga(mangaRepo.LookUp(_searchCriteria));
            //--LoadDataToControls_Generic(genericRepo.LookUp(searchCriteria));
        }

        private void LoadDataToControls_Anime(IEnumerable<Anime> data)
        {
            ListViewItem item;
            foreach (Anime entity in data)
            {
                item = new ListViewItem(new[] {entity.Name, entity.ToString()});
                item.Tag = entity;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        private void LoadDataToControls_Manga(IEnumerable<Manga> data)
        {
            ListViewItem item;
            foreach (Manga entity in data)
            {
                item = new ListViewItem(new[] {entity.Name, entity.ToString()});
                item.Tag = entity;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        private void LoadDataToControls_Generic(IEnumerable<EntitySource> data)
        {
            ListViewItem item;
            foreach (EntitySource entity in data)
            {
                item = new ListViewItem(new[] {entity.Name, entity.ToString()});
                item.Tag = entity;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        #endregion
    }
}