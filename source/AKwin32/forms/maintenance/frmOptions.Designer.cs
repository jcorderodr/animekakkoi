namespace AKwin32.forms.maintenance
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageConn = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.data_btnCleanItems = new System.Windows.Forms.Button();
            this.data_btnCleanAll = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageConn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPageConn);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPageConn
            // 
            resources.ApplyResources(this.tabPageConn, "tabPageConn");
            this.tabPageConn.Controls.Add(this.groupBox1);
            this.tabPageConn.Name = "tabPageConn";
            this.tabPageConn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkUseProxy);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtPass
            // 
            resources.ApplyResources(this.txtPass, "txtPass");
            this.txtPass.Name = "txtPass";
            // 
            // txtUser
            // 
            resources.ApplyResources(this.txtUser, "txtUser");
            this.txtUser.Name = "txtUser";
            // 
            // txtDomain
            // 
            resources.ApplyResources(this.txtDomain, "txtDomain");
            this.txtDomain.Name = "txtDomain";
            // 
            // txtHost
            // 
            resources.ApplyResources(this.txtHost, "txtHost");
            this.txtHost.Name = "txtHost";
            this.txtHost.Validated += new System.EventHandler(this.txtHost_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkUseProxy
            // 
            resources.ApplyResources(this.chkUseProxy, "chkUseProxy");
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            // 
            // tabPageData
            // 
            resources.ApplyResources(this.tabPageData, "tabPageData");
            this.tabPageData.Controls.Add(this.groupBox2);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.data_btnCleanItems);
            this.groupBox2.Controls.Add(this.data_btnCleanAll);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // data_btnCleanItems
            // 
            resources.ApplyResources(this.data_btnCleanItems, "data_btnCleanItems");
            this.data_btnCleanItems.Image = global::AKwin32.Properties.Resources.close;
            this.data_btnCleanItems.Name = "data_btnCleanItems";
            this.data_btnCleanItems.UseVisualStyleBackColor = true;
            this.data_btnCleanItems.Click += new System.EventHandler(this.data_btnCleanItems_Click);
            // 
            // data_btnCleanAll
            // 
            resources.ApplyResources(this.data_btnCleanAll, "data_btnCleanAll");
            this.data_btnCleanAll.Image = global::AKwin32.Properties.Resources.delete;
            this.data_btnCleanAll.Name = "data_btnCleanAll";
            this.data_btnCleanAll.UseVisualStyleBackColor = true;
            this.data_btnCleanAll.Click += new System.EventHandler(this.data_btnCleanAll_Click);
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
            // frmOptions
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmOptions";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageConn.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageData.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageConn;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button data_btnCleanAll;
        private System.Windows.Forms.Button data_btnCleanItems;
    }
}
