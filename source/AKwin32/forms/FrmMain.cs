using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AKwin32.forms
{
    public partial class FrmMain : frmBase
    {


        public FrmMain()
        {
            InitializeComponent();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            maintenance.frmUsers frmUsr = new maintenance.frmUsers();
            if (frmUsr.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) this.Close();
            this.OnPropertiesChange();
        }


        #region File Menu

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintenance.frmUsers frm = new maintenance.frmUsers();
            frm.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkForExit())
                this.Close();
        }

        #endregion

        #region management Menu

        private void newAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            management.frmNewItem frm = new management.frmNewItem();
            frm.SetEntity(typeof(Framework.entity.Anime));
            frm.ShowDialog(this);
        }

        private void manageAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            management.frmMgmtAnime frm = new management.frmMgmtAnime();
            frm.Show(this);
        }

        private void newMangaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            management.frmNewItem frm = new management.frmNewItem();
            frm.SetEntity(typeof(Framework.entity.Manga));
            frm.ShowDialog(this);
        }

        private void manageMangaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.management.frmMgmtManga frm = new management.frmMgmtManga();
            frm.Show(this);
        }

        #endregion

        #region Tools Menu

        private void mcAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.frmImporter frm = new tools.frmImporter();
            frm.ImportMethod = Framework.util.IMPORT_SOURCES.MCANIME;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                management.frmManagement frmMg = null;
                if (frm.MediaType == typeof(Framework.entity.Anime))
                {
                    frmMg = new management.frmMgmtAnime();
                }
                else if (frm.MediaType == typeof(Framework.entity.Manga))
                {
                    frmMg = new management.frmMgmtManga();
                }
                frmMg.SetItemsList(frm.ResultedList, frm.MediaType);
                frmMg.Show();
            }
        }

        private void mcAnimeKronosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.frmImporter frm = new tools.frmImporter();
            frm.ImportMethod = Framework.util.IMPORT_SOURCES.MCANIME_KRONOS;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                management.frmManagement frmMg = null;
                if (frm.MediaType == typeof(Framework.entity.Anime))
                {
                    frmMg = new management.frmMgmtAnime();
                }
                else if (frm.MediaType == typeof(Framework.entity.Manga))
                {
                    frmMg = new management.frmMgmtManga();
                }
                frmMg.SetItemsList(frm.ResultedList, frm.MediaType);
                frmMg.Show();
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region About Menu

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http:\\www.google.com.do");
        }

        private void aboutAkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (maintenance.AboutBox fbox = new maintenance.AboutBox())
            {
                fbox.ShowDialog(this);
            }
        }

        #endregion


        #region Functions

        private bool checkForExit()
        {
            return true;
        }

        protected internal void OnPropertiesChange()
        {
            stripStatusUser.Text = Program.SystemUser.Name;
        }


        #endregion

    }
}
