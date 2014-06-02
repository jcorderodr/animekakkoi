using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.Media;
using AnimeKakkoi.Core.Util;

namespace AnimeKakkoi.App.Forms.Management
{

    public partial class FrmImporter : Base
    {

        private readonly WebImporter _import;

        private ISource _source;

        private Uri _link;

        private Type _mediaType;

        #region Properties

        public ImportSources ImportMethod { get; set; }

        public IEnumerable<object> ResultedList
        {
            get { return _source.ResultedItems; }
        }

        public Type MediaType
        {
            get { return _mediaType; }
            set { _mediaType = value; }
        }

        #endregion

        public FrmImporter()
        {
            InitializeComponent();
            _import = new WebImporter();
        }

        #region UI Events

        private void frmImporter_Load(object sender, EventArgs e)
        {
            lblType.Text = ImportMethod.ToString();
            base.FillComboBoxCatalog(cbSourceType, Catalog.GetEntitiesValidTypes());
        }

        private void lblType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_link != null)
                System.Diagnostics.Process.Start(_link.OriginalString);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Form_State == FormUsingState.Ready)
            {
                this.DialogResult = DialogResult.OK;
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
            if (cbSourceType.SelectedIndex == -1 || cbSourceType.Text.Equals("--"))
                return false;

            string uri = txtUrl.Text;
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                return false;

            _link = new Uri(uri);
            return WebImporter.IsValidateSources(this.ImportMethod, uri);
        }

        private void BeginProcess()
        {
            try
            {
                var response = _import.TryRequest(_link.AbsoluteUri);
                _import.Type = this.ImportMethod;
                _import.Html = response;
                _source = _import.GetSource(cbSourceType.Text, ref _mediaType);
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
                case ImportSources.MCANIME:
                case ImportSources.MCANIME_KRONOS:
                    var mcanime = _source as McAnime;
                    ShowResult(mcanime.Items);
                    break;
                case ImportSources.MY_ANIME_LIST:
                    var resx = _source as MyAnimeList;
                    ShowResult(resx.Items);
                    break;

                default:
                    break;
            }
        }

        private void SaveSourceToUser()
        {
            //TODO: Save the source (link.AbsoluteUri) for  future uses

        }

        private void StartProcess()
        {
            BeginProcess();
            if (_source != null)
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