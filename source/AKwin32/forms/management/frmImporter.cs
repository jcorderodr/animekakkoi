using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Framework.util;
using Framework.media;

namespace AKwin32.forms.management
{
    public partial class frmImporter : AKwin32.forms.frmBase
    {

        private Framework.util.WebImporter import;

        private Framework.media.ISource source;

        private Uri link;

        private Type mediaType;

        #region Properties

        public IMPORT_SOURCES ImportMethod { get; set; }

        public List<object> ResultedList { get; set; }

        public Type MediaType
        {
            get
            {
                return mediaType;
            }
            set
            {
                mediaType = value;
            }
        }

        #endregion

        public frmImporter()
        {
            InitializeComponent();
            import = new Framework.util.WebImporter();
        }

        #region UI Events

        private void frmImporter_Load(object sender, EventArgs e)
        {
            lblType.Text = ImportMethod.ToString();
            base.FillComboBoxCatalog(cbSourceType, Framework.io.Catalog.GetEntitiesValidTypes());

        }

        private void lblType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (link != null)
                System.Diagnostics.Process.Start(link.OriginalString); ;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (Form_State == FORM_USING_STATE.READY)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

            if (Form_State == FORM_USING_STATE.LISTENING)
            {
                if (CheckInput())
                {
                    tools.WaitingBox wbox = new tools.WaitingBox();
                    wbox.StartUntilStopped(this);
                    //
                    StartProcess();
                    SaveSourceToUser();
                    //
                    wbox.Stop();
                }
                else
                {
                    lblUriError.Text = Errors["invalid_input"];
                }
            }

        }

        #endregion

        #region Functions

        private bool CheckInput()
        {
            if (cbSourceType.SelectedIndex == -1 || cbSourceType.Text == "--") return false;

            string uri = txtUrl.Text;
            if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                link = new Uri(uri);
                return WebImporter.isValidateSources(this.ImportMethod, uri);
            }
            else
                return false;
        }

        private void BeginProcess()
        {
            try
            {
                string response = import.TryRequest(link.AbsoluteUri);
                import.Type = this.ImportMethod;
                import.HTML = response;
                source = import.GetSource(cbSourceType.Text, ref mediaType);
            }
            catch (Exception we)
            {
                base.ShowError(this,
                    String.Format("{1} : {0}",
                    we.Message, base.Errors["communication_failed"]));
            }
        }

        private void EndProcess()
        {
            switch (ImportMethod)
            {
                case IMPORT_SOURCES.MCANIME:
                case IMPORT_SOURCES.MCANIME_KRONOS:
                    McAnime mcanime = source as McAnime;
                    ShowResult(mcanime.Items);
                    break;
                case IMPORT_SOURCES.MY_ANIME_LIST:
                    MyAnimeList resx = source as MyAnimeList;
                    ShowResult(resx.Items);
                    break;

                default:
                    break;
            }
        }

        private void SaveSourceToUser()
        {
            Program.SystemUser.AddSource(link.AbsoluteUri);
            Framework.repo.xml.UserRepository repo = new Framework.repo.xml.UserRepository();
            repo.Change(Program.SystemUser);
        }

        private void StartProcess()
        {
            BeginProcess();
            if (source != null)
            {
                EndProcess();

                lblType.Enabled = true;
                Form_State = FORM_USING_STATE.READY;
                btnAccept.Text = Messages["save"];
                lblUriError.Text = "";
            }
        }

        private void ShowResult(List<object> list)
        {
            lblElementsCount.Text = list.Count + "";
            this.ResultedList = list;
        }

        #endregion

    }



}
