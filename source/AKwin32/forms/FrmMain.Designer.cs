﻿namespace AKwin32.forms
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
            this.quickSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formattedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listForSharingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newMangaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageMangaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoAkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mcAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mcAnimeKronosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataCheckerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stripStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelShorcuts = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefreshSrc = new System.Windows.Forms.Button();
            this.btnSharing = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelShorcuts.SuspendLayout();
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
            this.quickSearchToolStripMenuItem,
            this.toolStripSeparator5,
            this.usersToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportToolStripMenuItem,
            this.toolStripSeparator6,
            this.exitToolStripMenuItem});
            this.fileToolStripMenu.Name = "fileToolStripMenu";
            // 
            // quickSearchToolStripMenuItem
            // 
            resources.ApplyResources(this.quickSearchToolStripMenuItem, "quickSearchToolStripMenuItem");
            this.quickSearchToolStripMenuItem.Name = "quickSearchToolStripMenuItem";
            this.quickSearchToolStripMenuItem.Click += new System.EventHandler(this.quickSearchToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
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
            // exportToolStripMenuItem
            // 
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formattedTextToolStripMenuItem,
            this.listForSharingToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            // 
            // formattedTextToolStripMenuItem
            // 
            resources.ApplyResources(this.formattedTextToolStripMenuItem, "formattedTextToolStripMenuItem");
            this.formattedTextToolStripMenuItem.Name = "formattedTextToolStripMenuItem";
            this.formattedTextToolStripMenuItem.Click += new System.EventHandler(this.formattedTextToolStripMenuItem_Click);
            // 
            // listForSharingToolStripMenuItem
            // 
            resources.ApplyResources(this.listForSharingToolStripMenuItem, "listForSharingToolStripMenuItem");
            this.listForSharingToolStripMenuItem.Name = "listForSharingToolStripMenuItem";
            this.listForSharingToolStripMenuItem.Click += new System.EventHandler(this.listForSharingToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
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
            this.backUpToolStripMenuItem,
            this.toolStripSeparator4,
            this.preferencesToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenu.Name = "toolsToolStripMenu";
            // 
            // importerToolStripMenuItem
            // 
            resources.ApplyResources(this.importerToolStripMenuItem, "importerToolStripMenuItem");
            this.importerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoAkToolStripMenuItem,
            this.toolStripSeparator7,
            this.mcAnimeToolStripMenuItem,
            this.mcAnimeKronosToolStripMenuItem});
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            // 
            // archivoAkToolStripMenuItem
            // 
            resources.ApplyResources(this.archivoAkToolStripMenuItem, "archivoAkToolStripMenuItem");
            this.archivoAkToolStripMenuItem.Name = "archivoAkToolStripMenuItem";
            this.archivoAkToolStripMenuItem.Click += new System.EventHandler(this.archivoAkToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
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
            // backUpToolStripMenuItem
            // 
            resources.ApplyResources(this.backUpToolStripMenuItem, "backUpToolStripMenuItem");
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
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
            // panelShorcuts
            // 
            resources.ApplyResources(this.panelShorcuts, "panelShorcuts");
            this.panelShorcuts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelShorcuts.Controls.Add(this.btnSearch);
            this.panelShorcuts.Controls.Add(this.btnRefreshSrc);
            this.panelShorcuts.Controls.Add(this.btnSharing);
            this.panelShorcuts.Name = "panelShorcuts";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSearch.Image = global::AKwin32.Properties.Resources.search;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefreshSrc
            // 
            resources.ApplyResources(this.btnRefreshSrc, "btnRefreshSrc");
            this.btnRefreshSrc.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRefreshSrc.Image = global::AKwin32.Properties.Resources.refresh;
            this.btnRefreshSrc.Name = "btnRefreshSrc";
            this.btnRefreshSrc.UseVisualStyleBackColor = false;
            this.btnRefreshSrc.Click += new System.EventHandler(this.btnRefreshSrc_Click);
            // 
            // btnSharing
            // 
            resources.ApplyResources(this.btnSharing, "btnSharing");
            this.btnSharing.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSharing.Image = global::AKwin32.Properties.Resources.chat;
            this.btnSharing.Name = "btnSharing";
            this.btnSharing.UseVisualStyleBackColor = false;
            this.btnSharing.Click += new System.EventHandler(this.btnSharing_Click);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelShorcuts);
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
            this.panelShorcuts.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem quickSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panelShorcuts;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formattedTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Button btnSharing;
        private System.Windows.Forms.Button btnRefreshSrc;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripMenuItem archivoAkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem listForSharingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
    }
}