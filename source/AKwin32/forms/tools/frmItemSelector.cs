using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.Core.Data;
using AnimeKakkoi.Core.Data.Json;
using AnimeKakkoi.Core.Entities;


namespace AnimeKakkoi.App.Forms.tools
{
    public partial class frmItemSelector : BaseToolbox
    {
        private IAnimeRepository animeRepo;
        private IMangaRepository mangaRepo;

        private List<object> _userSelection;

        public List<object> UserSelection
        {
            get { return _userSelection; }
        }


        public frmItemSelector()
        {
            InitializeComponent();

            animeRepo = new AnimeRepository();
            mangaRepo = new MangaRepository();
            _userSelection = new List<object>();
        }


        private void frmItemSelector_Load(object sender, EventArgs e)
        {
            try
            {
                FillComponents();
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in itemsGridView.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[0].Value))
                    continue;

                _userSelection.Add(row.Tag);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FillComponents()
        {
            foreach (Anime entity in animeRepo.GetAll())
            {
                var row = new DataGridViewRow();
                row.CreateCells(itemsGridView, false, entity.Name, entity.ToString());
                row.Tag = entity;
                itemsGridView.Rows.Add(row);
            }
            foreach (Manga entity in mangaRepo.GetAll())
            {
                var row = new DataGridViewRow();
                row.SetValues(false, entity.Name, entity.ToString());
                row.Tag = entity;
                itemsGridView.Rows.Add(row);
            }
            itemsGridView.Refresh();
        }
    }
}