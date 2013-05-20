namespace AKwin32.forms.maintenance
{
    partial class frmUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.panelBase = new System.Windows.Forms.Panel();
            this.btnEraseUser = new System.Windows.Forms.Button();
            this.lblSources = new System.Windows.Forms.Label();
            this.listViewSources = new System.Windows.Forms.ListView();
            this.sourceList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboxUsers = new System.Windows.Forms.ComboBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.panelBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBase
            // 
            resources.ApplyResources(this.panelBase, "panelBase");
            this.panelBase.Controls.Add(this.btnEraseUser);
            this.panelBase.Controls.Add(this.lblSources);
            this.panelBase.Controls.Add(this.listViewSources);
            this.panelBase.Controls.Add(this.cboxUsers);
            this.panelBase.Controls.Add(this.lblUsers);
            this.panelBase.Name = "panelBase";
            // 
            // btnEraseUser
            // 
            resources.ApplyResources(this.btnEraseUser, "btnEraseUser");
            this.btnEraseUser.Name = "btnEraseUser";
            this.btnEraseUser.UseVisualStyleBackColor = true;
            this.btnEraseUser.Click += new System.EventHandler(this.btnEraseUser_Click);
            // 
            // lblSources
            // 
            resources.ApplyResources(this.lblSources, "lblSources");
            this.lblSources.Name = "lblSources";
            // 
            // listViewSources
            // 
            resources.ApplyResources(this.listViewSources, "listViewSources");
            this.listViewSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sourceList});
            this.listViewSources.Name = "listViewSources";
            this.listViewSources.UseCompatibleStateImageBehavior = false;
            this.listViewSources.View = System.Windows.Forms.View.List;
            this.listViewSources.SelectedIndexChanged += new System.EventHandler(this.listViewSources_SelectedIndexChanged);
            // 
            // sourceList
            // 
            resources.ApplyResources(this.sourceList, "sourceList");
            // 
            // cboxUsers
            // 
            resources.ApplyResources(this.cboxUsers, "cboxUsers");
            this.cboxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUsers.FormattingEnabled = true;
            this.cboxUsers.Name = "cboxUsers";
            this.cboxUsers.SelectedIndexChanged += new System.EventHandler(this.cboxUsers_SelectedIndexChanged);
            // 
            // lblUsers
            // 
            resources.ApplyResources(this.lblUsers, "lblUsers");
            this.lblUsers.Name = "lblUsers";
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNewUser
            // 
            resources.ApplyResources(this.btnNewUser, "btnNewUser");
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // frmUsers
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.panelBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmUsers";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsers_FormClosing);
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.panelBase.ResumeLayout(false);
            this.panelBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboxUsers;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblSources;
        private System.Windows.Forms.ListView listViewSources;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.ColumnHeader sourceList;
        private System.Windows.Forms.Button btnEraseUser;
    }
}
