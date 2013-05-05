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
            this.listViewSources.Resize += new EventHandler(this.listViewSources_Resize);
            LoadControlsContent();
            //if (Program.SystemUser == null)
            //    this.btnCancel.Visible = false;

        }

        void listViewSources_Resize(object sender, EventArgs e)
        {
            listViewSources.Columns[0].Width = listViewSources.Width - 1;
        }

        private void frmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing && Program.SystemUser == null)
                Application.Exit();

            if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;

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
                User user = new User { Name = frmReq.UserInput };

                if (dataSource.FirstOrDefault(c=> c.Name == user.Name) != null)
                {
                    base.ShowError(this, base.Messages["user_exists"]);
                    return;
                }
                repo.Add(user);
                LoadControlsContent();
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
