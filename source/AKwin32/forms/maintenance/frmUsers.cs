using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Framework.repo.xml;
using Framework.entity;

namespace AKwin32.forms.maintenance
{
    public partial class frmUsers : AKwin32.forms.frmBaseToolbox
    {

        public User SelectedUser
        { get; set; }

        UserRepository repo;

        List<User> dataSource;

        public frmUsers()
        {
            InitializeComponent();
            repo = new UserRepository();
        }


        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.listViewSources.Resize += new System.EventHandler(listViewItems_Resize);
            LoadControlsContent();
            //if (Program.SystemUser == null)
            //    this.btnCancel.Visible = false;

            SizeLastColumn(sender as ListView);
        }

        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isValid())
            {
                base.ShowError(this, Program.Language.ErrorsLibrary["select_user"]);
                e.Cancel = true;
            }
        }

        private void listViewSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = listViewSources.Items[listViewSources.SelectedIndices[0]].Text;
            System.Diagnostics.Process.Start(item);
        }

        private void cboxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isValid())
            {
                User usr = cboxUsers.SelectedItem as User;
                listViewSources.Items.Clear();
                foreach (string s in usr.Sources)
                    listViewSources.Items.Add(s);
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                Program.SystemUser = cboxUsers.SelectedItem as User;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                base.ShowError(this, Program.Language.ErrorsLibrary["select_user"]);
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            tools.frmInputRequest frmReq = new tools.frmInputRequest();
            frmReq.SetUIProperties(base.Messages["new_user"], base.Messages["new_user_request"], !(Program.SystemUser == null));
            if (frmReq.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                repo.Add(new User { Name = frmReq.UserInput });
                LoadControlsContent();
                repo = null;
            }
        }


        private void LoadControlsContent()
        {
            dataSource = repo.GetAll().ToList();

            cboxUsers.DataSource = dataSource;
            cboxUsers.DisplayMember = "Name";
            cboxUsers.ValueMember = "Codigo";
        }

        private bool isValid()
        {
            return ((cboxUsers.SelectedItem as User) != null);
        }



    }
}
