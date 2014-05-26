#region

using System;
using System.Net;

#endregion

namespace AnimeKakkoi.App.Forms.Maintenance
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmOptions : FrmBaseToolbox
    {
        private WebProxy proxy;

        public frmOptions()
        {
            InitializeComponent();
        }

        #region GUI Events

        private void frmOptions_Load(object sender, EventArgs e)
        {
            proxy = (WebProxy) AnimeKakkoi.Framework.IO.AkConfiguration.GetProxy();
            txtHost.Text = proxy.Address.Authority;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValidInput())
            {
                SaveChanges();
                this.Close();
            }
        }

        #endregion

        #region tabPageUi

        #endregion

        #region tabPageConn

        private void txtHost_Validated(object sender, EventArgs e)
        {
        }

        #endregion

        #region tabPageData

        private void data_btnCleanItems_Click(object sender, EventArgs e)
        {
            var repos = new global::AnimeKakkoi.Framework.Repo.RepositoryResources();
            if (repos.ReleaseItems())
                base.ShowInformation(this, base.Messages["items_erased_sucess"]);
            else
                base.ShowInformation(this, base.Messages["items_erased_error"]);
        }

        private void data_btnCleanAll_Click(object sender, EventArgs e)
        {
            if (base.ShowQuestion(this, base.Messages["clean_database_question"]) !=
                System.Windows.Forms.DialogResult.Yes) return;

            var repos = new global::AnimeKakkoi.Framework.Repo.RepositoryResources();
            if (repos.ReleaseDatabase())
            {
                base.ShowInformation(this, base.Messages["database_erased_sucess"]);
                Program.SystemUser = null;
                var frm = new frmUsers();
                var frmUsr = new frmUsers();
                if (frmUsr.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            else
                base.ShowInformation(this, base.Messages["database_erased_error"]);
        }

        #endregion

        private bool isValidInput()
        {
            bool r = true;

            string pattern = @"(\d{1,3}\.){3}\d{1,3}:\d{2,5}";
            var regex = new System.Text.RegularExpressions.Regex(pattern);
            if (!regex.IsMatch(txtHost.Text))
            {
                r = false;
                base.ShowError(this, "proxy!");
                txtHost.Focus();
            }

            return r;
        }

        private void SaveChanges()
        {
            #region Visual

            #endregion

            #region Connection

            var proxy = new WebProxy(txtHost.Text);
            var cred = new NetworkCredential(txtUser.Text, txtPass.Text, txtDomain.Text);
            proxy.Credentials = cred;

            AnimeKakkoi.Framework.IO.AkConfiguration.SetProxy(proxy);

            #endregion
        }
    }
}