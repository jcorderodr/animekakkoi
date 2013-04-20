namespace AKwin32.forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newMangaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageMangaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mcAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mcAnimeKronosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataCheckerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stripStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenu,
            this.managementToolStripMenu,
            this.toolsToolStripMenu,
            this.aboutToolStripMenu});
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenu
            // 
            resources.ApplyResources(this.fileToolStripMenu, "fileToolStripMenu");
            this.fileToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenu.Name = "fileToolStripMenu";
            // 
            // usersToolStripMenuItem
            // 
            resources.ApplyResources(this.usersToolStripMenuItem, "usersToolStripMenuItem");
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // managementToolStripMenu
            // 
            resources.ApplyResources(this.managementToolStripMenu, "managementToolStripMenu");
            this.managementToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAnimeToolStripMenuItem,
            this.manageAnimeToolStripMenuItem,
            this.toolStripSeparator1,
            this.newMangaToolStripMenuItem,
            this.manageMangaToolStripMenuItem});
            this.managementToolStripMenu.Name = "managementToolStripMenu";
            // 
            // newAnimeToolStripMenuItem
            // 
            resources.ApplyResources(this.newAnimeToolStripMenuItem, "newAnimeToolStripMenuItem");
            this.newAnimeToolStripMenuItem.Name = "newAnimeToolStripMenuItem";
            this.newAnimeToolStripMenuItem.Click += new System.EventHandler(this.newAnimeToolStripMenuItem_Click);
            // 
            // manageAnimeToolStripMenuItem
            // 
            resources.ApplyResources(this.manageAnimeToolStripMenuItem, "manageAnimeToolStripMenuItem");
            this.manageAnimeToolStripMenuItem.Name = "manageAnimeToolStripMenuItem";
            this.manageAnimeToolStripMenuItem.Click += new System.EventHandler(this.manageAnimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // newMangaToolStripMenuItem
            // 
            resources.ApplyResources(this.newMangaToolStripMenuItem, "newMangaToolStripMenuItem");
            this.newMangaToolStripMenuItem.Name = "newMangaToolStripMenuItem";
            this.newMangaToolStripMenuItem.Click += new System.EventHandler(this.newMangaToolStripMenuItem_Click);
            // 
            // manageMangaToolStripMenuItem
            // 
            resources.ApplyResources(this.manageMangaToolStripMenuItem, "manageMangaToolStripMenuItem");
            this.manageMangaToolStripMenuItem.Name = "manageMangaToolStripMenuItem";
            this.manageMangaToolStripMenuItem.Click += new System.EventHandler(this.manageMangaToolStripMenuItem_Click);
            // 
            // toolsToolStripMenu
            // 
            resources.ApplyResources(this.toolsToolStripMenu, "toolsToolStripMenu");
            this.toolsToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importerToolStripMenuItem,
            this.toolStripSeparator2,
            this.dataCheckerToolStripMenuItem,
            this.toolStripSeparator4,
            this.preferencesToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenu.Name = "toolsToolStripMenu";
            // 
            // importerToolStripMenuItem
            // 
            resources.ApplyResources(this.importerToolStripMenuItem, "importerToolStripMenuItem");
            this.importerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcAnimeToolStripMenuItem,
            this.mcAnimeKronosToolStripMenuItem});
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            // 
            // mcAnimeToolStripMenuItem
            // 
            resources.ApplyResources(this.mcAnimeToolStripMenuItem, "mcAnimeToolStripMenuItem");
            this.mcAnimeToolStripMenuItem.Name = "mcAnimeToolStripMenuItem";
            this.mcAnimeToolStripMenuItem.Click += new System.EventHandler(this.mcAnimeToolStripMenuItem_Click);
            // 
            // mcAnimeKronosToolStripMenuItem
            // 
            resources.ApplyResources(this.mcAnimeKronosToolStripMenuItem, "mcAnimeKronosToolStripMenuItem");
            this.mcAnimeKronosToolStripMenuItem.Name = "mcAnimeKronosToolStripMenuItem";
            this.mcAnimeKronosToolStripMenuItem.Click += new System.EventHandler(this.mcAnimeKronosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // dataCheckerToolStripMenuItem
            // 
            resources.ApplyResources(this.dataCheckerToolStripMenuItem, "dataCheckerToolStripMenuItem");
            this.dataCheckerToolStripMenuItem.Name = "dataCheckerToolStripMenuItem";
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // preferencesToolStripMenuItem
            // 
            resources.ApplyResources(this.preferencesToolStripMenuItem, "preferencesToolStripMenuItem");
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenu
            // 
            resources.ApplyResources(this.aboutToolStripMenu, "aboutToolStripMenu");
            this.aboutToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutAkToolStripMenuItem});
            this.aboutToolStripMenu.Name = "aboutToolStripMenu";
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutAkToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutAkToolStripMenuItem, "aboutAkToolStripMenuItem");
            this.aboutAkToolStripMenuItem.Name = "aboutAkToolStripMenuItem";
            this.aboutAkToolStripMenuItem.Click += new System.EventHandler(this.aboutAkToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripStatusUser});
            this.statusStrip.Name = "statusStrip";
            // 
            // stripStatusUser
            // 
            resources.ApplyResources(this.stripStatusUser, "stripStatusUser");
            this.stripStatusUser.Name = "stripStatusUser";
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem newAnimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageAnimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newMangaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageMangaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mcAnimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mcAnimeKronosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel stripStatusUser;
        private System.Windows.Forms.ToolStripMenuItem dataCheckerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}