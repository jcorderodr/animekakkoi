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
            this.panelBase = new System.Windows.Forms.Panel();
            this.lblSources = new System.Windows.Forms.Label();
            this.listViewSources = new System.Windows.Forms.ListView();
            this.cboxUsers = new System.Windows.Forms.ComboBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.sourceList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBase
            // 
            this.panelBase.Controls.Add(this.lblSources);
            this.panelBase.Controls.Add(this.listViewSources);
            this.panelBase.Controls.Add(this.cboxUsers);
            this.panelBase.Controls.Add(this.lblUsers);
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBase.Location = new System.Drawing.Point(0, 0);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(345, 200);
            this.panelBase.TabIndex = 0;
            // 
            // lblSources
            // 
            this.lblSources.AutoSize = true;
            this.lblSources.Location = new System.Drawing.Point(12, 59);
            this.lblSources.Name = "lblSources";
            this.lblSources.Size = new System.Drawing.Size(44, 13);
            this.lblSources.TabIndex = 4;
            this.lblSources.Text = "sources";
            // 
            // listViewSources
            // 
            this.listViewSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sourceList});
            this.listViewSources.Location = new System.Drawing.Point(33, 75);
            this.listViewSources.Name = "listViewSources";
            this.listViewSources.Size = new System.Drawing.Size(300, 113);
            this.listViewSources.TabIndex = 3;
            this.listViewSources.UseCompatibleStateImageBehavior = false;
            this.listViewSources.View = System.Windows.Forms.View.List;
            this.listViewSources.SelectedIndexChanged += new System.EventHandler(this.listViewSources_SelectedIndexChanged);
            this.listViewSources.Resize += new System.EventHandler(this.listViewSources_Resize);
            // 
            // cboxUsers
            // 
            this.cboxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUsers.FormattingEnabled = true;
            this.cboxUsers.Location = new System.Drawing.Point(33, 29);
            this.cboxUsers.Name = "cboxUsers";
            this.cboxUsers.Size = new System.Drawing.Size(189, 21);
            this.cboxUsers.TabIndex = 1;
            this.cboxUsers.SelectedIndexChanged += new System.EventHandler(this.cboxUsers_SelectedIndexChanged);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(12, 13);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(32, 13);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "users";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(177, 206);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "ok";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(258, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.Location = new System.Drawing.Point(12, 206);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(75, 23);
            this.btnNewUser.TabIndex = 3;
            this.btnNewUser.Text = "new";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // sourceList
            // 
            this.sourceList.Text = "";
            // 
            // frmUsers
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(345, 237);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.panelBase);
            this.Name = "frmUsers";
            this.Text = "Users";
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
    }
}
