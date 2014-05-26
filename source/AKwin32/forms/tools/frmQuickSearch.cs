#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.Framework.Entities;
using AnimeKakkoi.Framework.Repo.xml;

#endregion

namespace AnimeKakkoi.App.forms.tools
{
    public partial class frmQuickSearch : FrmBaseToolbox
    {
        private AnimeRepository animeRepo;
        private MangaRepository mangaRepo;
        //GenericRepository genericRepo;

        private string searchCriteria;

        public frmQuickSearch()
        {
            InitializeComponent();
            animeRepo = new AnimeRepository();
            mangaRepo = new MangaRepository();
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

            var frm = new management.frmEntityEdit();
            frm.SetEntityObject(item.Tag);
            if (item.Tag.GetType() == typeof (Anime))
                frm.SetRepository(animeRepo);
            else if (item.Tag.GetType() == typeof (Manga))
                frm.SetRepository(mangaRepo);
                //else if (item.Tag.GetType() == typeof(Framework.entity.EntitySource))
                //    frm.SetRepository(null);
            else
            {
                base.ShowError(this, base.Errors["entity_missed"]);
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
            searchCriteria = txtSearchCriteria.Text;
            ValidateInput();
        }

        private void ValidateInput()
        {
            if (String.IsNullOrEmpty(searchCriteria.Trim())) return;

            listViewItems.Items.Clear();
            LoadDataToControls_Anime(animeRepo.LookUp(searchCriteria));
            LoadDataToControls_Manga(mangaRepo.LookUp(searchCriteria));
            //--LoadDataToControls_Generic(genericRepo.LookUp(searchCriteria));
        }

        private void LoadDataToControls_Anime(IList<Anime> data)
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

        private void LoadDataToControls_Manga(IList<Manga> data)
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

        private void LoadDataToControls_Generic(IList<EntitySource> data)
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