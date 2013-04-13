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

namespace AKwin32.forms.tools
{
    public partial class frmImporter : AKwin32.forms.frmBase
    {

        //string sourceType;

        private Framework.util.Importer import;

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
            import = new Framework.util.Importer();
        }

        private void frmImporter_Load(object sender, EventArgs e)
        {
            lblType.Text = ImportMethod.ToString();
            cbSourceType.Items.Add("Anime");
            cbSourceType.Items.Add("Manga");
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
                    BeginProcess();
                    if (source != null)
                    {
                        EndProcess();
                        SaveSourceToUser();
                        lblType.Enabled = true;
                        Form_State = FORM_USING_STATE.READY;
                        btnAccept.Text = "save data";
                        lblUriError.Text = "";
                    }
                    //
                    wbox.Stop();
                }
                else
                {
                    lblUriError.Text = "inputted type/uri error";
                }
            }

        }

        private bool CheckInput()
        {
            if (cbSourceType.SelectedIndex == -1) return false;

            string uri = txtUrl.Text;
            if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                link = new Uri(uri);
                switch (this.ImportMethod)
                {
                    case IMPORT_SOURCES.MCANIME:
                        return uri.Contains("mcanime");
                    case IMPORT_SOURCES.MCANIME_KRONOS:
                        return uri.Contains("kronos");
                    default:
                        return false;
                }
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
                source = import.GetSource(response, cbSourceType.SelectedItem.ToString(), ref mediaType);
            }
            catch (Exception we)
            {
                base.ShowError(this,
                    String.Format("{1} : {0}",
                    we.Message, Program.Language.MessagesLibrary["communication_failed"]));
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
                default:
                    break;
            }
        }

        private void SaveSourceToUser()
        {
            Program.SystemUser.AddSource(link.AbsoluteUri);
        }

        private void ShowResult(List<object> list)
        {
            lblElementsCount.Text = list.Count + "";
            this.ResultedList = list;
        }


    }



}
