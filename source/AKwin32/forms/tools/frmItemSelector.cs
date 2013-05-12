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


        public frmItemSelector()
        {
            InitializeComponent();

            animeRepo = new AnimeRepository();
            mangaRepo = new MangaRepository();
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
            foreach (DataRowView row in itemsGridView.Rows)
            {
                if (!Convert.ToBoolean(row[0]))
                    continue;

            }
        }

        private void FillComponents()
        {

            foreach (Framework.entity.Anime entity in animeRepo.GetAll())
            {
                //Framework.entity.EntitySource entity = temp as Framework.entity.EntitySource;

                itemsGridView.Rows.Add(false, entity.Name, entity.ToString());
            }
            foreach (object temp in mangaRepo.GetAll())
            {
                Framework.entity.EntitySource entity = temp as Framework.entity.EntitySource;

                itemsGridView.Rows.Add(false, entity.Name, entity.ToString());
            }
            itemsGridView.Refresh();
        }


    }
}
