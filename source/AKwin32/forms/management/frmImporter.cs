#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.Framework.IO;
using AnimeKakkoi.Framework.Repo.xml;
using AnimeKakkoi.Framework.media;
using AnimeKakkoi.Framework.util;

#endregion

namespace AnimeKakkoi.App.forms.management
{
    public partial class frmImporter : FrmBase
    {
        private WebImporter import;

        private ISource source;

        private Uri link;

        private Type mediaType;

        #region Properties

        public IMPORT_SOURCES ImportMethod { get; set; }

        public List<object> ResultedList { get; set; }

        public Type MediaType
        {
            get { return mediaType; }
            set { mediaType = value; }
        }

        #endregion

        public frmImporter()
        {
            InitializeComponent();
            import = new WebImporter();
        }

        #region UI Events

        private void frmImporter_Load(object sender, EventArgs e)
        {
            lblType.Text = ImportMethod.ToString();
            base.FillComboBoxCatalog(cbSourceType, Catalog.GetEntitiesValidTypes());
        }

        private void lblType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (link != null)
                System.Diagnostics.Process.Start(link.OriginalString);
            ;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Form_State == FormUsingState.Ready)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

            if (Form_State == FormUsingState.Listening)
            {
                if (CheckInput())
                {
                    var wbox = new tools.WaitingBox();
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
                    var mcanime = source as McAnime;
                    ShowResult(mcanime.Items);
                    break;
                case IMPORT_SOURCES.MY_ANIME_LIST:
                    var resx = source as MyAnimeList;
                    ShowResult(resx.Items);
                    break;

                default:
                    break;
            }
        }

        private void SaveSourceToUser()
        {
            Program.SystemUser.AddSource(link.AbsoluteUri);
            var repo = new UserRepository();
            repo.Change(Program.SystemUser);
        }

        private void StartProcess()
        {
            BeginProcess();
            if (source != null)
            {
                EndProcess();

                lblType.Enabled = true;
                Form_State = FormUsingState.Ready;
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