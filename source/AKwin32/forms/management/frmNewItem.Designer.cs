namespace AnimeKakkoi.App.Forms.Management
{
    partial class FrmNewItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewItem));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Rating = new System.Windows.Forms.MaskedTextBox();
            this.txt_Progress = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Category = new System.Windows.Forms.ComboBox();
            this.chkBox_Favorite = new System.Windows.Forms.CheckBox();
            this.cb_State = new System.Windows.Forms.ComboBox();
            this.txt_Comment = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lblEpi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::AnimeKakkoi.App.Properties.Resources.button_cancel__x16;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Image = global::AnimeKakkoi.App.Properties.Resources.button_ok_x16;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Rating);
            this.groupBox1.Controls.Add(this.txt_Progress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_Category);
            this.groupBox1.Controls.Add(this.chkBox_Favorite);
            this.groupBox1.Controls.Add(this.cb_State);
            this.groupBox1.Controls.Add(this.txt_Comment);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.lblEpi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblComment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblState);
            this.groupBox1.Controls.Add(this.lblName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txt_Rating
            // 
            resources.ApplyResources(this.txt_Rating, "txt_Rating");
            this.txt_Rating.Name = "txt_Rating";
            this.txt_Rating.Validated += new System.EventHandler(this.txt_Rating_Validated);
            // 
            // txt_Progress
            // 
            resources.ApplyResources(this.txt_Progress, "txt_Progress");
            this.txt_Progress.Culture = new System.Globalization.CultureInfo("en-029");
            this.txt_Progress.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txt_Progress.HidePromptOnLeave = true;
            this.txt_Progress.Name = "txt_Progress";
            this.txt_Progress.ResetOnSpace = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cb_Category
            // 
            resources.ApplyResources(this.cb_Category, "cb_Category");
            this.cb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Category.FormattingEnabled = true;
            this.cb_Category.Name = "cb_Category";
            // 
            // chkBox_Favorite
            // 
            resources.ApplyResources(this.chkBox_Favorite, "chkBox_Favorite");
            this.chkBox_Favorite.Name = "chkBox_Favorite";
            this.chkBox_Favorite.UseVisualStyleBackColor = true;
            // 
            // cb_State
            // 
            resources.ApplyResources(this.cb_State, "cb_State");
            this.cb_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_State.FormattingEnabled = true;
            this.cb_State.Name = "cb_State";
            // 
            // txt_Comment
            // 
            resources.ApplyResources(this.txt_Comment, "txt_Comment");
            this.txt_Comment.Name = "txt_Comment";
            // 
            // txt_Name
            // 
            resources.ApplyResources(this.txt_Name, "txt_Name");
            this.txt_Name.Name = "txt_Name";
            // 
            // lblEpi
            // 
            resources.ApplyResources(this.lblEpi, "lblEpi");
            this.lblEpi.Name = "lblEpi";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // lblState
            // 
            resources.ApplyResources(this.lblState, "lblState");
            this.lblState.Name = "lblState";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // FrmNewItem
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmNewItem";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNewItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txt_Progress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Category;
        private System.Windows.Forms.CheckBox chkBox_Favorite;
        private System.Windows.Forms.ComboBox cb_State;
        private System.Windows.Forms.TextBox txt_Comment;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lblEpi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.MaskedTextBox txt_Rating;
    }
}
