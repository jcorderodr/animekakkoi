namespace AKwin32.forms.management
{
    partial class frmNewItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_Category = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBox_Favorite = new System.Windows.Forms.CheckBox();
            this.cb_State = new System.Windows.Forms.ComboBox();
            this.txt_Comment = new System.Windows.Forms.TextBox();
            this.txt_Rating = new System.Windows.Forms.TextBox();
            this.txt_Episodes = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblEpi = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb_Category);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkBox_Favorite);
            this.panel1.Controls.Add(this.cb_State);
            this.panel1.Controls.Add(this.txt_Comment);
            this.panel1.Controls.Add(this.txt_Rating);
            this.panel1.Controls.Add(this.txt_Episodes);
            this.panel1.Controls.Add(this.txt_Name);
            this.panel1.Controls.Add(this.lblComment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Controls.Add(this.lblEpi);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 278);
            this.panel1.TabIndex = 3;
            // 
            // cb_Category
            // 
            this.cb_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Category.FormattingEnabled = true;
            this.cb_Category.Location = new System.Drawing.Point(127, 69);
            this.cb_Category.Name = "cb_Category";
            this.cb_Category.Size = new System.Drawing.Size(188, 21);
            this.cb_Category.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "lblCategory";
            // 
            // chkBox_Favorite
            // 
            this.chkBox_Favorite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBox_Favorite.AutoSize = true;
            this.chkBox_Favorite.Location = new System.Drawing.Point(347, 71);
            this.chkBox_Favorite.Name = "chkBox_Favorite";
            this.chkBox_Favorite.Size = new System.Drawing.Size(61, 17);
            this.chkBox_Favorite.TabIndex = 2;
            this.chkBox_Favorite.Text = "favorite";
            this.chkBox_Favorite.UseVisualStyleBackColor = true;
            // 
            // cb_State
            // 
            this.cb_State.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_State.FormattingEnabled = true;
            this.cb_State.Location = new System.Drawing.Point(127, 146);
            this.cb_State.Name = "cb_State";
            this.cb_State.Size = new System.Drawing.Size(286, 21);
            this.cb_State.TabIndex = 5;
            // 
            // txt_Comment
            // 
            this.txt_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Comment.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Comment.Location = new System.Drawing.Point(127, 185);
            this.txt_Comment.Multiline = true;
            this.txt_Comment.Name = "txt_Comment";
            this.txt_Comment.Size = new System.Drawing.Size(286, 62);
            this.txt_Comment.TabIndex = 6;
            this.txt_Comment.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Rating
            // 
            this.txt_Rating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Rating.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Rating.Location = new System.Drawing.Point(127, 108);
            this.txt_Rating.Name = "txt_Rating";
            this.txt_Rating.Size = new System.Drawing.Size(74, 20);
            this.txt_Rating.TabIndex = 3;
            this.txt_Rating.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Episodes
            // 
            this.txt_Episodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Episodes.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Episodes.Location = new System.Drawing.Point(336, 107);
            this.txt_Episodes.Name = "txt_Episodes";
            this.txt_Episodes.Size = new System.Drawing.Size(74, 20);
            this.txt_Episodes.TabIndex = 4;
            this.txt_Episodes.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(127, 31);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(286, 20);
            this.txt_Name.TabIndex = 0;
            this.txt_Name.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(29, 187);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(71, 16);
            this.lblComment.TabIndex = 11;
            this.lblComment.Text = "lblComment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "lblRate";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(45, 148);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(55, 16);
            this.lblState.TabIndex = 10;
            this.lblState.Text = "lblState";
            // 
            // lblEpi
            // 
            this.lblEpi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEpi.AutoSize = true;
            this.lblEpi.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpi.Location = new System.Drawing.Point(255, 110);
            this.lblEpi.Name = "lblEpi";
            this.lblEpi.Size = new System.Drawing.Size(38, 16);
            this.lblEpi.TabIndex = 12;
            this.lblEpi.Text = "lblEpi";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(46, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 16);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "lblName";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(338, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(239, 286);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "ok";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmNewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(426, 317);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "frmNewItem";
            this.Text = "NewItem";
            this.Load += new System.EventHandler(this.frmNewItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_Category;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkBox_Favorite;
        private System.Windows.Forms.ComboBox cb_State;
        private System.Windows.Forms.TextBox txt_Comment;
        private System.Windows.Forms.TextBox txt_Rating;
        private System.Windows.Forms.TextBox txt_Episodes;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblEpi;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
    }
}
