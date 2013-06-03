using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.repo.xml;

namespace AKwin32.forms.tools
{
    public partial class frmItemSelector : AKwin32.forms.frmBaseToolbox
    {

        AnimeRepository animeRepo;
        MangaRepository mangaRepo;

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
            foreach (Framework.entity.Anime entity in animeRepo.GetAll())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(itemsGridView, false, entity.Name, entity.ToString());
                row.Tag = entity;
                itemsGridView.Rows.Add(row);
            }
            foreach (Framework.entity.Manga entity in mangaRepo.GetAll())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.SetValues(false, entity.Name, entity.ToString());
                row.Tag = entity;
                itemsGridView.Rows.Add(row);
            }
            itemsGridView.Refresh();
        }


    }
}
