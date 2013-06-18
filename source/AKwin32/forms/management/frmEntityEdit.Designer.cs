namespace AKwin32.forms.management
{
    partial class frmEntityEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntityEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Favorite = new System.Windows.Forms.Label();
            this.cb_State = new System.Windows.Forms.ComboBox();
            this.cb_Category = new System.Windows.Forms.ComboBox();
            this.txt_Comment = new System.Windows.Forms.TextBox();
            this.txt_Rating = new System.Windows.Forms.TextBox();
            this.txt_Episodes = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblEpi = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Favorite);
            this.panel1.Controls.Add(this.cb_State);
            this.panel1.Controls.Add(this.cb_Category);
            this.panel1.Controls.Add(this.txt_Comment);
            this.panel1.Controls.Add(this.txt_Rating);
            this.panel1.Controls.Add(this.txt_Episodes);
            this.panel1.Controls.Add(this.txt_Name);
            this.panel1.Controls.Add(this.lblComment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Controls.Add(this.lblEpi);
            this.panel1.Controls.Add(this.lblName);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lbl_Favorite
            // 
            resources.ApplyResources(this.lbl_Favorite, "lbl_Favorite");
            this.lbl_Favorite.Image = global::AKwin32.Properties.Resources.fav_no_media;
            this.lbl_Favorite.MinimumSize = new System.Drawing.Size(16, 16);
            this.lbl_Favorite.Name = "lbl_Favorite";
            this.lbl_Favorite.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbl_Favorite_MouseClick);
            // 
            // cb_State
            // 
            this.cb_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_State.FormattingEnabled = true;
            resources.ApplyResources(this.cb_State, "cb_State");
            this.cb_State.Name = "cb_State";
            this.cb_State.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // cb_Category
            // 
            this.cb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Category.FormattingEnabled = true;
            resources.ApplyResources(this.cb_Category, "cb_Category");
            this.cb_Category.Name = "cb_Category";
            // 
            // txt_Comment
            // 
            resources.ApplyResources(this.txt_Comment, "txt_Comment");
            this.txt_Comment.Name = "txt_Comment";
            this.txt_Comment.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Rating
            // 
            resources.ApplyResources(this.txt_Rating, "txt_Rating");
            this.txt_Rating.Name = "txt_Rating";
            this.txt_Rating.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Episodes
            // 
            resources.ApplyResources(this.txt_Episodes, "txt_Episodes");
            this.txt_Episodes.Name = "txt_Episodes";
            this.txt_Episodes.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Name
            // 
            resources.ApplyResources(this.txt_Name, "txt_Name");
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // lblComment
            // 
            resources.ApplyResources(this.lblComment, "lblComment");
            this.lblComment.Name = "lblComment";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblState
            // 
            resources.ApplyResources(this.lblState, "lblState");
            this.lblState.Name = "lblState";
            // 
            // lblEpi
            // 
            resources.ApplyResources(this.lblEpi, "lblEpi");
            this.lblEpi.Name = "lblEpi";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
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
            this.btnCancel.Image = global::AKwin32.Properties.Resources.button_cancel__x16;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmEntityEdit
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.panel1);
            this.Name = "frmEntityEdit";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmEntityEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        protected internal System.Windows.Forms.Label lbl_Favorite;
        protected internal System.Windows.Forms.ComboBox cb_State;
        protected internal System.Windows.Forms.ComboBox cb_Category;
        protected internal System.Windows.Forms.TextBox txt_Comment;
        protected internal System.Windows.Forms.TextBox txt_Rating;
        protected internal System.Windows.Forms.TextBox txt_Episodes;
        protected internal System.Windows.Forms.TextBox txt_Name;
        protected internal System.Windows.Forms.Label lblComment;
        protected internal System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Label lblState;
        protected internal System.Windows.Forms.Label lblEpi;
        protected internal System.Windows.Forms.Label lblName;
    }
}
