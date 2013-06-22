using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AKwin32.com.util;

namespace AKwin32.forms
{
    public partial class FrmMain : frmBase
    {

        public FrmMain()
        {
            InitializeComponent();
            //
            archivoAkToolStripMenuItem.Enabled = false;
        }


        #region GUI Events

        private void FrmMain_Load(object sender, EventArgs e)
        {
            maintenance.frmUsers frmUsr = new maintenance.frmUsers();
            if (frmUsr.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                return;
            }
            this.OnPropertiesChange();
            EventLogger.Write(Configuration.ApplicationLoggerFile, "system_start");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason != CloseReason.ApplicationExitCall)
                checkForExit();
        }

        #region File Menu


        private void quickSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.frmQuickSearch frm = new tools.frmQuickSearch();
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintenance.frmUsers frm = new maintenance.frmUsers();
            frm.ShowDialog(this);
        }

        private void userActionhistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tools.frmActionHistory frm = new tools.frmActionHistory();
            frm.ShowDialog(this);
        }

        private void formattedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSharingTextFile();
        }

        private void listForSharingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.tools.frmExporter frm = new tools.frmExporter();
            frm.Show();
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

        private void archivoAkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = Program.AppTitle;
            fileDialog.AddExtension = true;
            fileDialog.AutoUpgradeEnabled = true;
            fileDialog.Filter = Framework.io.FileProperties.AppSharingFileFilterName;
            if (fileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

            Framework.util.FileManager importer;
            importer = new Framework.util.FileManager(fileDialog.FileName);
            importer.Load();

            base.ShowInformation(this, base.Messages[Framework.io.LanguageExpressions.OPERATION_SUCESS]);
        }

        private void mcAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            management.frmImporter frm = new management.frmImporter();
            frm.ImportMethod = Framework.util.IMPORT_SOURCES.MCANIME;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.ResultedList.Count < 1 || frm.MediaType == null) return;
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
            management.frmImporter frm = new management.frmImporter();
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

        private void myAnimeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            management.frmImporter frm = new management.frmImporter();
            frm.ImportMethod = Framework.util.IMPORT_SOURCES.MY_ANIME_LIST;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.ResultedList.Count < 1 || frm.MediaType == null) return;
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

        private void updateSourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowInformation(this, base.Messages["version_pro"]);
        }

        private void dataCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.ShowInformation(this, base.Messages["version_pro"]);
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.tools.frmBackUp frm = new tools.frmBackUp();
            frm.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forms.maintenance.frmPreferences frm = new maintenance.frmPreferences();
            frm.ShowDialog(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintenance.frmOptions frm = new maintenance.frmOptions();
            frm.ShowDialog(this);
        }

        #endregion

        #region About Menu

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(base.Configuration.ProductUrl);
            }
            catch { }
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string route = "mailto:blugletek@gmail.com?subject=AnimeKakkoi+Contact";
            try
            {
                System.Diagnostics.Process.Start(route);
            }
            catch { }
        }


        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string route = Properties.Settings.Default.ApplicationBugReport;
            try
            {
                System.Diagnostics.Process.Start(route);
            }
            catch { }
        }

        private void searchUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string metadata = Properties.Settings.Default.ApplicationMetadataUrl;
            try
            {
                com.net.Update upd = com.net.Update.CheckForUpdate(metadata);

                if (upd.IsNewVersion)
                    base.ShowInformation(this, base.Messages["update_available"] + upd.Version);
                else
                    base.ShowInformation(this, base.Messages["last_version"] + upd.Version);

            }
            catch { base.ShowError(this, base.Errors["error_search_update"]); }

        }

        private void versionProToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("=== AnimeKakkoi Pro ===");
            builder.AppendLine("La Versión Pro es una versión más completa, de funcionalidad más amplia y atractiva.");
            builder.AppendLine();
            builder.AppendLine("# Features #");
            builder.AppendLine("- Datos guardados en la nube/Information in the cloud");
            builder.AppendLine("- Actualización automática de la base de datos/Automatic updates of info based on sources");
            builder.AppendLine("- Comprobración de integridad de los registros/Check out of data's integration");
            builder.AppendLine("- Integración con Redes Sociales/Integration with Social Networks");
            builder.AppendLine("");

            base.ShowInformation(this, builder.ToString());
        }

        private void aboutAkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (maintenance.AboutBox fbox = new maintenance.AboutBox())
            {
                fbox.ShowDialog(this);
            }
        }

        #endregion

        #endregion

        #region Shortcuts

        private void btnSharing_Click(object sender, EventArgs e)
        {
            this.listForSharingToolStripMenuItem_Click(sender, e);
        }

        private void btnAnime_Click(object sender, EventArgs e)
        {
            this.manageAnimeToolStripMenuItem_Click(sender, e);
        }

        private void btnManga_Click(object sender, EventArgs e)
        {
            this.manageMangaToolStripMenuItem_Click(sender, e);
        }


        #endregion

        #region Functions

        private bool checkForExit()
        {
            //Framework.repo.xml.UserRepository repo = new Framework.repo.xml.UserRepository();
            //if (Program.SystemUser != null)
            //    repo.Change(Program.SystemUser);
            return true;
        }

        protected internal void OnPropertiesChange()
        {
            stripStatusUser.Text = Program.SystemUser.Name;
        }

        private void CreateSharingTextFile()
        {
            #region Selection

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = Program.AppTitle;
            saveDialog.AddExtension = true;
            saveDialog.AutoUpgradeEnabled = true;
            saveDialog.Filter = "Texto (*.txt) | *.txt";
            saveDialog.FileName = "ak_" + DateTime.Now.ToShortDateString().Replace("/", "-");
            if (saveDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

            #endregion

            //Just in case that take too much time.
            //--tools.WaitingBox wBox = new tools.WaitingBox();
            //--wBox.StartUntilStopped();

            #region Load Data

            StringBuilder buffer = new StringBuilder();

            buffer.AppendLine();
            buffer.AppendLine(DateTime.Now.ToLongDateString());
            buffer.AppendLine();

            Framework.repo.xml.AnimeRepository animeRepo = new Framework.repo.xml.AnimeRepository();
            List<Framework.entity.Anime> animes = animeRepo.GetAll().ToList();

            buffer.AppendLine("#######------- Animes -------#######");
            foreach (Framework.entity.Anime item in animes)
                buffer.AppendLine(item.ToString());

            animeRepo = null;
            animes = null;

            buffer.AppendLine();
            buffer.AppendLine("[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]");
            buffer.AppendLine();

            Framework.repo.xml.MangaRepository mangaRepo = new Framework.repo.xml.MangaRepository();
            List<Framework.entity.Manga> mangas = mangaRepo.GetAll().ToList();

            buffer.AppendLine("#######------- Mangas/Comics -------#######");
            foreach (Framework.entity.Manga item in mangas)
                buffer.AppendLine(item.ToString());

            mangaRepo = null;
            mangas = null;

            #endregion

            #region Rev

            buffer.Replace("QUEUE", Messages["QUEUE"]);
            buffer.Replace("WATCHING", Messages["WATCHING"]);
            buffer.Replace("WATCHED", Messages["WATCHED"]);
            buffer.Replace("TAKED_DOWN", Messages["TAKED_DOWN"]);
            buffer.Replace("WANT_TO", Messages["WANT_TO"]);

            #endregion

            //--wBox.Stop();
            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(saveDialog.FileName);
                writer.Write(buffer.ToString());
                writer.Flush();
                writer.Close();
                base.ShowInformation(this, base.Messages["sharing_file"]);
            }
            catch { }
        }

        #endregion



















    }
}

