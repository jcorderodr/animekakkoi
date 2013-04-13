namespace AKwin32.forms.management
{
    partial class frmManagement
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbBoxItemType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveItem = new System.Windows.Forms.Button();
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
            this.listViewItems = new System.Windows.Forms.ListView();
            this.itemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(568, 448);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "ok";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(667, 448);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbBoxItemType);
            this.groupBox2.Controls.Add(this.lblType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(754, 40);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "filterZone";
            // 
            // cbBoxItemType
            // 
            this.cbBoxItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxItemType.FormattingEnabled = true;
            this.cbBoxItemType.Location = new System.Drawing.Point(74, 15);
            this.cbBoxItemType.Name = "cbBoxItemType";
            this.cbBoxItemType.Size = new System.Drawing.Size(121, 21);
            this.cbBoxItemType.TabIndex = 1;
            this.cbBoxItemType.SelectedValueChanged += new System.EventHandler(this.cbBoxItemType_SelectedValueChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(12, 16);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(49, 16);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "lblType";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.listViewItems);
            this.groupBox1.Location = new System.Drawing.Point(0, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 396);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnRemoveItem);
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
            this.panel1.Location = new System.Drawing.Point(444, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 377);
            this.panel1.TabIndex = 2;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(22, 332);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // lbl_Favorite
            // 
            this.lbl_Favorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Favorite.AutoSize = true;
            this.lbl_Favorite.Image = global::AKwin32.Properties.Resources.fav_no_media;
            this.lbl_Favorite.Location = new System.Drawing.Point(269, 13);
            this.lbl_Favorite.MinimumSize = new System.Drawing.Size(16, 16);
            this.lbl_Favorite.Name = "lbl_Favorite";
            this.lbl_Favorite.Size = new System.Drawing.Size(16, 16);
            this.lbl_Favorite.TabIndex = 3;
            this.lbl_Favorite.Click += new System.EventHandler(this.lblFavorite_Click);
            // 
            // cb_State
            // 
            this.cb_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_State.FormattingEnabled = true;
            this.cb_State.Location = new System.Drawing.Point(117, 71);
            this.cb_State.Name = "cb_State";
            this.cb_State.Size = new System.Drawing.Size(168, 21);
            this.cb_State.TabIndex = 2;
            this.cb_State.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // cb_Category
            // 
            this.cb_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Category.FormattingEnabled = true;
            this.cb_Category.Location = new System.Drawing.Point(117, 111);
            this.cb_Category.Name = "cb_Category";
            this.cb_Category.Size = new System.Drawing.Size(168, 21);
            this.cb_Category.TabIndex = 2;
            this.cb_Category.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Comment
            // 
            this.txt_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Comment.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Comment.Location = new System.Drawing.Point(117, 229);
            this.txt_Comment.Multiline = true;
            this.txt_Comment.Name = "txt_Comment";
            this.txt_Comment.Size = new System.Drawing.Size(168, 62);
            this.txt_Comment.TabIndex = 1;
            this.txt_Comment.TextChanged += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Rating
            // 
            this.txt_Rating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Rating.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Rating.Location = new System.Drawing.Point(117, 151);
            this.txt_Rating.Name = "txt_Rating";
            this.txt_Rating.Size = new System.Drawing.Size(168, 20);
            this.txt_Rating.TabIndex = 1;
            this.txt_Rating.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Episodes
            // 
            this.txt_Episodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Episodes.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Episodes.Location = new System.Drawing.Point(117, 190);
            this.txt_Episodes.Name = "txt_Episodes";
            this.txt_Episodes.Size = new System.Drawing.Size(168, 20);
            this.txt_Episodes.TabIndex = 1;
            this.txt_Episodes.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Name
            // 
            this.txt_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Name.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(117, 32);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(168, 20);
            this.txt_Name.TabIndex = 1;
            this.txt_Name.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(19, 231);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(71, 16);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "lblComment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "lblRate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "lblCategory";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(35, 74);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(55, 16);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "lblState";
            // 
            // lblEpi
            // 
            this.lblEpi.AutoSize = true;
            this.lblEpi.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpi.Location = new System.Drawing.Point(52, 192);
            this.lblEpi.Name = "lblEpi";
            this.lblEpi.Size = new System.Drawing.Size(38, 16);
            this.lblEpi.TabIndex = 0;
            this.lblEpi.Text = "lblEpi";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(36, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "lblName";
            // 
            // listViewItems
            // 
            this.listViewItems.AllowColumnReorder = true;
            this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemName,
            this.itemCategory});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(6, 16);
            this.listViewItems.MultiSelect = false;
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(435, 377);
            this.listViewItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewItems.TabIndex = 1;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            this.listViewItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewItems_ItemSelectionChanged);
            this.listViewItems.Resize += new System.EventHandler(this.listViewItems_Resize);
            // 
            // itemName
            // 
            this.itemName.Text = "itemName";
            this.itemName.Width = 282;
            // 
            // itemCategory
            // 
            this.itemCategory.Text = "itemCategory";
            this.itemCategory.Width = 144;
            // 
            // frmManagement
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(754, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MGMT - ";
            this.Load += new System.EventHandler(this.frmManagement_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader itemName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ColumnHeader itemCategory;
        protected internal System.Windows.Forms.Button btnAccept;
        protected internal System.Windows.Forms.Button btnCancel;
        protected internal System.Windows.Forms.TextBox txt_Name;
        protected internal System.Windows.Forms.Label lblComment;
        protected internal System.Windows.Forms.Label lblState;
        protected internal System.Windows.Forms.Label lblEpi;
        protected internal System.Windows.Forms.Label lblName;
        protected internal System.Windows.Forms.ComboBox cbBoxItemType;
        protected internal System.Windows.Forms.ComboBox cb_Category;
        protected internal System.Windows.Forms.TextBox txt_Comment;
        protected internal System.Windows.Forms.TextBox txt_Episodes;
        protected internal System.Windows.Forms.TextBox txt_Rating;
        protected internal System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.Label lbl_Favorite;
        protected internal System.Windows.Forms.ListView listViewItems;
        protected internal System.Windows.Forms.ComboBox cb_State;
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Button btnRemoveItem;
    }
}