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

        #region Private Functions

        private bool checkForExit()
        {
            return true;
        }

        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkForExit())
                this.Close();
        }

        private void newAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anime.frmNewAnime frm = new anime.frmNewAnime();
            frm.ShowDialog(this);
        }

        private void manageAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anime.frmManagementAnime frm = new anime.frmManagementAnime();
            frm.Show(this);
        }

        private void importerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.frmImporter frm = new tools.frmImporter();
            frm.Show(this);
        }
    }
}
