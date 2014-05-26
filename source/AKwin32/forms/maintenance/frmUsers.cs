#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.Framework.Entities;
using AnimeKakkoi.Framework.Repo.xml;

#endregion

namespace AnimeKakkoi.App.Forms.Maintenance
{
    public partial class frmUsers : FrmBaseToolbox
    {
        public User SelectedUser { get; set; }

        private UserRepository repo;

        private List<User> dataSource;

        public frmUsers()
        {
            InitializeComponent();
            repo = new UserRepository();
        }

        #region GUI Events

        private void frmUsers_Load(object sender, EventArgs e)
        {
            this.listViewSources.Resize += this.listViewSources_Resize;
            LoadControlsContent();
        }

        private void listViewSources_Resize(object sender, EventArgs e)
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
                base.ShowError(this, Program.Language.MessagesLibrary["select_user"]);
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
                var usr = cboxUsers.SelectedItem as User;
                listViewSources.Items.Clear();
                foreach (string s in usr.Sources)
                    listViewSources.Items.Add(s);
            }
        }

        private void btnEraseUser_Click(object sender, EventArgs e)
        {
            var usr = cboxUsers.SelectedItem as User;
            if (usr == null) return;
            repo.Remove(usr);
            listViewSources.Items.Clear();
            LoadControlsContent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                Program.SystemUser = cboxUsers.SelectedItem as User;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                base.ShowError(this, Program.Language.MessagesLibrary["select_user"]);
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            var frmReq = new AnimeKakkoi.App.forms.tools.frmInputRequest();
            frmReq.SetUIProperties(base.Messages["new_user"], base.Messages["new_user_request"],
                                   !(Program.SystemUser == null));
            if (frmReq.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                var user = new User {Name = frmReq.UserInput};

                if (dataSource.FirstOrDefault(c => c.Name == user.Name) != null)
                {
                    base.ShowError(this, base.Messages["user_exists"]);
                    return;
                }
                repo.Add(user);
                LoadControlsContent();
            }
        }

        #endregion

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