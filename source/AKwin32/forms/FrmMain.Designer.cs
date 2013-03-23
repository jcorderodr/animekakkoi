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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newMangaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageMangaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenu,
            this.managementToolStripMenu,
            this.toolsToolStripMenu,
            this.aboutToolStripMenu});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenu
            // 
            this.fileToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenu.Name = "fileToolStripMenu";
            resources.ApplyResources(this.fileToolStripMenu, "fileToolStripMenu");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // managementToolStripMenu
            // 
            this.managementToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAnimeToolStripMenuItem,
            this.manageAnimeToolStripMenuItem,
            this.toolStripSeparator1,
            this.newMangaToolStripMenuItem,
            this.manageMangaToolStripMenuItem});
            this.managementToolStripMenu.Name = "managementToolStripMenu";
            resources.ApplyResources(this.managementToolStripMenu, "managementToolStripMenu");
            // 
            // newAnimeToolStripMenuItem
            // 
            this.newAnimeToolStripMenuItem.Name = "newAnimeToolStripMenuItem";
            resources.ApplyResources(this.newAnimeToolStripMenuItem, "newAnimeToolStripMenuItem");
            this.newAnimeToolStripMenuItem.Click += new System.EventHandler(this.newAnimeToolStripMenuItem_Click);
            // 
            // manageAnimeToolStripMenuItem
            // 
            this.manageAnimeToolStripMenuItem.Name = "manageAnimeToolStripMenuItem";
            resources.ApplyResources(this.manageAnimeToolStripMenuItem, "manageAnimeToolStripMenuItem");
            this.manageAnimeToolStripMenuItem.Click += new System.EventHandler(this.manageAnimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // newMangaToolStripMenuItem
            // 
            this.newMangaToolStripMenuItem.Name = "newMangaToolStripMenuItem";
            resources.ApplyResources(this.newMangaToolStripMenuItem, "newMangaToolStripMenuItem");
            // 
            // manageMangaToolStripMenuItem
            // 
            this.manageMangaToolStripMenuItem.Name = "manageMangaToolStripMenuItem";
            resources.ApplyResources(this.manageMangaToolStripMenuItem, "manageMangaToolStripMenuItem");
            // 
            // toolsToolStripMenu
            // 
            this.toolsToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importerToolStripMenuItem,
            this.toolStripSeparator2,
            this.preferencesToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenu.Name = "toolsToolStripMenu";
            resources.ApplyResources(this.toolsToolStripMenu, "toolsToolStripMenu");
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            resources.ApplyResources(this.preferencesToolStripMenuItem, "preferencesToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // importerToolStripMenuItem
            // 
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            resources.ApplyResources(this.importerToolStripMenuItem, "importerToolStripMenuItem");
            this.importerToolStripMenuItem.Click += new System.EventHandler(this.importerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenu
            // 
            this.aboutToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutAkToolStripMenuItem});
            this.aboutToolStripMenu.Name = "aboutToolStripMenu";
            resources.ApplyResources(this.aboutToolStripMenu, "aboutToolStripMenu");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutAkToolStripMenuItem
            // 
            this.aboutAkToolStripMenuItem.Name = "aboutAkToolStripMenuItem";
            resources.ApplyResources(this.aboutAkToolStripMenuItem, "aboutAkToolStripMenuItem");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
    }
}