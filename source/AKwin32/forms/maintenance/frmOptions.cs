using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace AKwin32.forms.maintenance
{
    /// <summary>
    /// //TODO: implement this
    /// </summary>
    public partial class frmOptions : AKwin32.forms.frmBaseToolbox
    {

        WebProxy proxy;


        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            proxy = (WebProxy)Framework.io.Configuration.GetProxy();

            txtHost.Text = proxy.Address.ToString();

        }

        #region tabPageData

        private void data_btnCleanItems_Click(object sender, EventArgs e)
        {
            Framework.repo.RepositoryResources repos = new Framework.repo.RepositoryResources();
            if (repos.ReleaseItems())
                base.ShowInformation(this, base.Messages["items_erased_sucess"]);
            else
                base.ShowInformation(this, base.Messages["items_erased_error"]);
        }

        private void data_btnCleanAll_Click(object sender, EventArgs e)
        {
            if (base.ShowQuestion(this, base.Messages["clean_database_question"]) != System.Windows.Forms.DialogResult.Yes) return;

            Framework.repo.RepositoryResources repos = new Framework.repo.RepositoryResources();
            if (repos.ReleaseDatabase())
            {
                base.ShowInformation(this, base.Messages["database_erased_sucess"]);
                Program.SystemUser = null;
                frmUsers frm = new frmUsers();
                maintenance.frmUsers frmUsr = new maintenance.frmUsers();
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
