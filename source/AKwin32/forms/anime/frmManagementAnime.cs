using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework.repo;
using Framework.io;

namespace AKwin32.forms.anime
{
    public partial class frmManagementAnime : frmBase
    {
        Framework.data.Catalog catalog;

        public frmManagementAnime()
        {
            InitializeComponent();
            catalog = new Framework.data.Catalog();
        }

        private void frmManagementAnime_Load(object sender, EventArgs e)
        {
            //AnimeRepository repo = new AnimeRepository(Framework.io.Configuration.);


            cbBoxAnimeType.DataSource = catalog.GetAnimeTypes();
            cbBoxAnimeType.ValueMember = "Id";
            cbBoxAnimeType.DisplayMember = "Value";
        }
    }
}
