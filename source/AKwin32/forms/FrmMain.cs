#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms.Maintenance;
using AnimeKakkoi.App.Forms.maintenance;
using AnimeKakkoi.App.Forms.tools;
using AnimeKakkoi.App.Helpers;
using AnimeKakkoi.App.IO;
using AnimeKakkoi.App.Net;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.IO;
using AnimeKakkoi.Core.Lang;
using AnimeKakkoi.Core.Util;
using FileManager = AnimeKakkoi.Core.IO.FileManager;

#endregion

namespace AnimeKakkoi.App.Forms
{
    public partial class FrmMain : Base
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
            this.OnPropertiesChange();
            EventLogger.Write(AnimeKakkoi.App.IO.AppAkConfiguration.ApplicationLoggerFile, "system_start");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason != CloseReason.ApplicationExitCall)
                checkForExit();
        }

        #region File Menu

        private void quickSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AnimeKakkoi.App.Forms.tools.frmQuickSearch();
            frm.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void userActionhistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmActionHistory();
            frm.ShowDialog(this);
        }

        private void formattedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSharingTextFile();
        }

        private void listForSharingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AnimeKakkoi.App.Forms.tools.FrmExporter();
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
            var frm = new AnimeKakkoi.App.Forms.Management.FrmNewItem();
            frm.SetEntity(typeof (Anime));
            frm.ShowDialog(this);
        }

        private void manageAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AnimeKakkoi.App.Forms.Management.FrmMgmtAnime();
            frm.Show(this);
        }

        private void newMangaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AnimeKakkoi.App.Forms.Management.FrmNewItem();
            frm.SetEntity(typeof (Manga));
            frm.ShowDialog(this);
        }

        private void manageMangaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AnimeKakkoi.App.Forms.Management.FrmMgmtManga();
            frm.Show(this);
        }

        #endregion

        #region Tools Menu

        private void archivoAkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw  new NotImplementedException();

            var fileDialog = new OpenFileDialog
                {
                    Title = Program.APP_TITLE,
                    AddExtension = true,
                    AutoUpgradeEnabled = true,
                    //Filter = FileProperties.AppSharingFileFilterName
                };
            if (fileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) return;

            //var importer = new FileManager(fileDialog.FileName);
            //importer.Load();

            base.ShowInformation(this, base.Messages[LanguageExpressions.OPERATION_SUCESS]);
        }

        private void mcAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Forms.Management.FrmImporter();
            frm.ImportMethod = ImportSources.MCANIME;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (!frm.ResultedList.Any() || frm.MediaType == null) return;
                Management.FrmManagement frmMg = null;
                if (frm.MediaType == typeof (Anime))
                {
                    frmMg = new Management.FrmMgmtAnime();
                }
                else if (frm.MediaType == typeof (Manga))
                {
                    frmMg = new AnimeKakkoi.App.Forms.Management.FrmMgmtManga();
                }
                frmMg.SetItemsList(frm.ResultedList, frm.MediaType);
                frmMg.Show();
            }
        }

        private void mcAnimeKronosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Forms.Management.FrmImporter();
            frm.ImportMethod = ImportSources.MCANIME_KRONOS;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                Forms.Management.FrmManagement frmMg = null;
                if (frm.MediaType == typeof (Anime))
                {
                    frmMg = new Forms.Management.FrmMgmtAnime();
                }
                else if (frm.MediaType == typeof (Manga))
                {
                    frmMg = new Forms.Management.FrmMgmtManga();
                }
                frmMg.SetItemsList(frm.ResultedList, frm.MediaType);
                frmMg.Show();
            }
        }

        private void myAnimeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AnimeKakkoi.App.Forms.Management.FrmImporter();
            frm.ImportMethod = ImportSources.MY_ANIME_LIST;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (!frm.ResultedList.Any() || frm.MediaType == null) return;
                AnimeKakkoi.App.Forms.Management.FrmManagement frmMg = null;
                if (frm.MediaType == typeof (Anime))
                {
                    frmMg = new AnimeKakkoi.App.Forms.Management.FrmMgmtAnime();
                }
                else if (frm.MediaType == typeof (Manga))
                {
                    frmMg = new AnimeKakkoi.App.Forms.Management.FrmMgmtManga();
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
            var frm = new FrmBackUp();
            frm.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmPreferences();
            frm.ShowDialog(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmOptions();
            frm.ShowDialog(this);
        }

        #endregion

        #region About Menu

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(AppAkConfiguration.ProductUrl);
            }
            catch (Exception)
            {
            }
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string route = "mailto:aniboware@gmail.com?subject=AnimeKakkoi+Contact";
            try
            {
                System.Diagnostics.Process.Start(route);
            }
            catch (Exception)
            {
            }
        }


        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string route = "encrypted.google.com"; // IO.AppAkConfiguration.GetSetting("ApplicationBugReport");
            try
            {
                System.Diagnostics.Process.Start(route);
            }
            catch
            {
            }
        }

        private void searchUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string metadata = "encrypted.google.com"; //AkConfiguration.GetSetting("ApplicationMetadataUrl");
            try
            {
                Update upd = Net.Update.CheckForUpdate(metadata);

                if (upd.IsNewVersion)
                    base.ShowInformation(this, base.Messages["update_available"] + upd.Version);
                else
                    base.ShowInformation(this, base.Messages["last_version"] + upd.Version);
            }
            catch
            {
                base.ShowError(this, base.Errors["error_search_update"]);
            }
        }

        private void aboutAkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbox = new AboutBox())
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
            return true;
        }

        protected internal void OnPropertiesChange()
        {

        }

        private void CreateSharingTextFile()
        {
            #region Selection

            var saveDialog = new SaveFileDialog();
            saveDialog.Title = Program.APP_TITLE;
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

            var buffer = new StringBuilder();

            buffer.AppendLine();
            buffer.AppendLine(DateTime.Now.ToLongDateString());
            buffer.AppendLine();

            //TODO: Implement Sharing file
            /*
            var animeRepo = new global::AnimeKakkoi.Framework.Repo.xml.AnimeRepository();
            List<Anime> animes = animeRepo.GetAll().ToList();

            buffer.AppendLine("#######------- Animes -------#######");
            foreach (Anime item in animes)
                buffer.AppendLine(item.ToString());

            animeRepo = null;
            animes = null;

            buffer.AppendLine();
            buffer.AppendLine("[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]");
            buffer.AppendLine();

            var mangaRepo = new global::AnimeKakkoi.Framework.Repo.xml.MangaRepository();
            List<Manga> mangas = mangaRepo.GetAll().ToList();

            buffer.AppendLine("#######------- Mangas/Comics -------#######");
            foreach (Manga item in mangas)
                buffer.AppendLine(item.ToString());

            mangaRepo = null;
            mangas = null;
            */
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
                var writer = new System.IO.StreamWriter(saveDialog.FileName);
                writer.Write(buffer.ToString());
                writer.Flush();
                writer.Close();
                base.ShowInformation(this, base.Messages["sharing_file"]);
            }
            catch
            {
            }
        }

        #endregion
    }
}