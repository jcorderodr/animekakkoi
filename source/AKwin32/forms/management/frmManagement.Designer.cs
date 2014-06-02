namespace AnimeKakkoi.App.Forms.Management
{
    partial class FrmManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManagement));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.filter_cbBoxItemType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_ProgressString = new System.Windows.Forms.MaskedTextBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.lbl_Favorite = new System.Windows.Forms.Label();
            this.cb_State = new System.Windows.Forms.ComboBox();
            this.cb_Category = new System.Windows.Forms.ComboBox();
            this.txt_Comment = new System.Windows.Forms.TextBox();
            this.txt_Rating = new System.Windows.Forms.TextBox();
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
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.filter_cbBoxItemType);
            this.groupBox2.Controls.Add(this.lblType);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // filter_cbBoxItemType
            // 
            this.filter_cbBoxItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filter_cbBoxItemType.FormattingEnabled = true;
            resources.ApplyResources(this.filter_cbBoxItemType, "filter_cbBoxItemType");
            this.filter_cbBoxItemType.Name = "filter_cbBoxItemType";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.listViewItems);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.txt_ProgressString);
            this.panel1.Controls.Add(this.btnRemoveItem);
            this.panel1.Controls.Add(this.lbl_Favorite);
            this.panel1.Controls.Add(this.cb_State);
            this.panel1.Controls.Add(this.cb_Category);
            this.panel1.Controls.Add(this.txt_Comment);
            this.panel1.Controls.Add(this.txt_Rating);
            this.panel1.Controls.Add(this.txt_Name);
            this.panel1.Controls.Add(this.lblComment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Controls.Add(this.lblEpi);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Name = "panel1";
            // 
            // txt_ProgressString
            // 
            this.txt_ProgressString.Culture = new System.Globalization.CultureInfo("");
            resources.ApplyResources(this.txt_ProgressString, "txt_ProgressString");
            this.txt_ProgressString.Name = "txt_ProgressString";
            this.txt_ProgressString.SkipLiterals = false;
            this.txt_ProgressString.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txt_ProgressString.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // btnRemoveItem
            // 
            resources.ApplyResources(this.btnRemoveItem, "btnRemoveItem");
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // lbl_Favorite
            // 
            resources.ApplyResources(this.lbl_Favorite, "lbl_Favorite");
            this.lbl_Favorite.Image = global::AnimeKakkoi.App.Properties.Resources.fav_no_media;
            this.lbl_Favorite.MinimumSize = new System.Drawing.Size(16, 16);
            this.lbl_Favorite.Name = "lbl_Favorite";
            this.lbl_Favorite.Click += new System.EventHandler(this.lblFavorite_Click);
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
            this.cb_Category.Validated += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Comment
            // 
            resources.ApplyResources(this.txt_Comment, "txt_Comment");
            this.txt_Comment.Name = "txt_Comment";
            this.txt_Comment.TextChanged += new System.EventHandler(this.guiField_Validated);
            // 
            // txt_Rating
            // 
            resources.ApplyResources(this.txt_Rating, "txt_Rating");
            this.txt_Rating.Name = "txt_Rating";
            this.txt_Rating.Validated += new System.EventHandler(this.guiField_Validated);
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
            // listViewItems
            // 
            this.listViewItems.AllowColumnReorder = true;
            resources.ApplyResources(this.listViewItems, "listViewItems");
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemName,
            this.itemCategory});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.GridLines = true;
            this.listViewItems.HideSelection = false;
            this.listViewItems.MultiSelect = false;
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            this.listViewItems.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewItems_DrawColumnHeader);
            this.listViewItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewItems_ItemSelectionChanged);
            // 
            // itemName
            // 
            resources.ApplyResources(this.itemName, "itemName");
            // 
            // itemCategory
            // 
            resources.ApplyResources(this.itemCategory, "itemCategory");
            // 
            // FrmManagement
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmManagement";
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
        protected internal System.Windows.Forms.ComboBox filter_cbBoxItemType;
        protected internal System.Windows.Forms.ComboBox cb_Category;
        protected internal System.Windows.Forms.TextBox txt_Comment;
        protected internal System.Windows.Forms.TextBox txt_Rating;
        protected internal System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.Label lbl_Favorite;
        protected internal System.Windows.Forms.ListView listViewItems;
        protected internal System.Windows.Forms.ComboBox cb_State;
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Button btnRemoveItem;
        protected internal System.Windows.Forms.MaskedTextBox txt_ProgressString;
    }
}