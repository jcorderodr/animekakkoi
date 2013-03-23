using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework.entity;

namespace AKwin32.forms.anime
{
    public partial class frmNewAnime : frmBaseToolbox
    {
        public frmNewAnime()
        {
            InitializeComponent();
        }

        private void frmNew_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Anime anime = new Anime();

            anime.Codigo = 1;
            anime.Estado = ANIME_STATE.QUEUE; 
            anime.Nombre = "Mirai Nikki";
            anime.Comentario = "";
            anime.Captiulos = 24;

            Framework.repo.AnimeRepository repo ;
            repo = new Framework.repo.AnimeRepository(Framework.io.Configuration.GetAkFile(anime.Estado));
            repo.Add(anime);
        }
    }
}
