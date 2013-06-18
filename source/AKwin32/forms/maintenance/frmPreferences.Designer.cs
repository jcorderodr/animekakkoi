namespace AKwin32.forms.maintenance
{
    partial class frmPreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreferences));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkBoxInstantSearch = new System.Windows.Forms.CheckBox();
            this.cbBoxLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageUi = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabelControlsStyle = new System.Windows.Forms.LinkLabel();
            this.linkLabelFontsStyle = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabelFontColor = new System.Windows.Forms.LinkLabel();
            this.panelColorSample = new System.Windows.Forms.Panel();
            this.linkLabelColor = new System.Windows.Forms.LinkLabel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageUi.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelColorSample.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPageGeneral);
            this.tabControl1.Controls.Add(this.tabPageUi);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabPageGeneral, "tabPageGeneral");
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.cbBoxLanguage);
            this.groupBox2.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkBoxInstantSearch);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // chkBoxInstantSearch
            // 
            resources.ApplyResources(this.chkBoxInstantSearch, "chkBoxInstantSearch");
            this.chkBoxInstantSearch.Name = "chkBoxInstantSearch";
            this.chkBoxInstantSearch.UseVisualStyleBackColor = true;
            // 
            // cbBoxLanguage
            // 
            this.cbBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxLanguage.FormattingEnabled = true;
            this.cbBoxLanguage.Items.AddRange(new object[] {
            resources.GetString("cbBoxLanguage.Items"),
            resources.GetString("cbBoxLanguage.Items1")});
            resources.ApplyResources(this.cbBoxLanguage, "cbBoxLanguage");
            this.cbBoxLanguage.Name = "cbBoxLanguage";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabPageUi
            // 
            this.tabPageUi.Controls.Add(this.groupBox1);
            this.tabPageUi.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.tabPageUi, "tabPageUi");
            this.tabPageUi.Name = "tabPageUi";
            this.tabPageUi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.linkLabelControlsStyle);
            this.groupBox1.Controls.Add(this.linkLabelFontsStyle);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // linkLabelControlsStyle
            // 
            resources.ApplyResources(this.linkLabelControlsStyle, "linkLabelControlsStyle");
            this.linkLabelControlsStyle.Name = "linkLabelControlsStyle";
            this.linkLabelControlsStyle.TabStop = true;
            this.linkLabelControlsStyle.Click += new System.EventHandler(this.linkLabelControlsStyle_Click);
            // 
            // linkLabelFontsStyle
            // 
            this.linkLabelFontsStyle.ActiveLinkColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.linkLabelFontsStyle, "linkLabelFontsStyle");
            this.linkLabelFontsStyle.LinkColor = System.Drawing.SystemColors.Highlight;
            this.linkLabelFontsStyle.Name = "linkLabelFontsStyle";
            this.linkLabelFontsStyle.TabStop = true;
            this.linkLabelFontsStyle.Click += new System.EventHandler(this.linkLabelFontsStyle_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.linkLabelFontColor);
            this.groupBox3.Controls.Add(this.panelColorSample);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // linkLabelFontColor
            // 
            resources.ApplyResources(this.linkLabelFontColor, "linkLabelFontColor");
            this.linkLabelFontColor.Name = "linkLabelFontColor";
            this.linkLabelFontColor.TabStop = true;
            this.linkLabelFontColor.Click += new System.EventHandler(this.linkLabelFontColor_Click);
            // 
            // panelColorSample
            // 
            this.panelColorSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelColorSample.Controls.Add(this.linkLabelColor);
            resources.ApplyResources(this.panelColorSample, "panelColorSample");
            this.panelColorSample.Name = "panelColorSample";
            // 
            // linkLabelColor
            // 
            resources.ApplyResources(this.linkLabelColor, "linkLabelColor");
            this.linkLabelColor.LinkColor = System.Drawing.Color.Black;
            this.linkLabelColor.Name = "linkLabelColor";
            this.linkLabelColor.TabStop = true;
            this.linkLabelColor.Click += new System.EventHandler(this.linkLabelColor_Click);
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Image = global::AKwin32.Properties.Resources.button_ok_x16;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::AKwin32.Properties.Resources.button_cancel__x16;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // colorDialog
            // 
            this.colorDialog.Color = System.Drawing.Color.Transparent;
            // 
            // fontDialog
            // 
            this.fontDialog.Color = System.Drawing.Color.DimGray;
            this.fontDialog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ShowApply = true;
            // 
            // frmPreferences
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmPreferences";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPreferences_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageUi.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelColorSample.ResumeLayout(false);
            this.panelColorSample.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panelColorSample;
        private System.Windows.Forms.LinkLabel linkLabelColor;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.LinkLabel linkLabelFontsStyle;
        private System.Windows.Forms.LinkLabel linkLabelFontColor;
        private System.Windows.Forms.LinkLabel linkLabelControlsStyle;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBoxLanguage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkBoxInstantSearch;
    }
}
