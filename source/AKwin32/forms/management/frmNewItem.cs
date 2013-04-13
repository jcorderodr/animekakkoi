using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.entity;

namespace AKwin32.forms.management
{
    public partial class frmNewItem : AKwin32.forms.frmBaseToolbox, INewItem
    {

        Type entityType;

        Framework.io.Catalog catalog;

        public frmNewItem()
        {
            InitializeComponent();
            catalog = new Framework.io.Catalog();
            //
        }

        #region GUI Events
        
        private void frmNewItem_Load(object sender, EventArgs e)
        {
            if (entityType == null)
            {
                base.ShowError(this, Program.Language.ErrorsLibrary["entity_missed"]);
                this.Close();
            }
            ((INewItem)this).DoVisualChanges();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
                if (((INewItem)this).ToRegisterItem())
                {
                    base.ShowInformation(this,
                     Program.Language.MessagesLibrary["items_saved"]);
                    CleanUIComponents();
                }
                else
                    base.ShowError(this,
                     Program.Language.ErrorsLibrary["items_error"]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = base.ShowQuestion(this, Program.Language.MessagesLibrary["exit_question"]);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void guiField_Validated(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;

            //if (ctrl.GetType() == typeof(TextBox))
            //    ctrl.Text = util.Expression.GetOnlyNumbersFromText(ctrl.Text) + "";

        }

        #endregion

        #region Functions

        void CleanUIComponents()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                    ctrl.Text = "";
                if (ctrl.GetType() == typeof(ComboBox))
                    ((ComboBox)ctrl).SelectedIndex = 0;
            }
            chkBox_Favorite.Checked = false;
        }

        void INewItem.DoVisualChanges()
        {
            cb_State.DataSource = catalog.GetEntitiesStateTypes();
            cb_State.ValueMember = "Id";
            cb_State.DisplayMember = "Value";
        }

        private bool isAnimeType()
        {
            Anime anime = new Anime();
            anime.Name = txt_Name.Text;
            anime.Favorite = chkBox_Favorite.Checked;

            anime.Category = (ANIME_TYPE)Enum.Parse(typeof(ANIME_TYPE), cb_Category.SelectedValue + "");
            anime.State = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), cb_State.SelectedValue + "");

            anime.Comment = txt_Comment.Text;
            anime.Rating = util.Expression.StringIfNull(txt_Rating.Text, 0);
            anime.Episodes = util.Expression.StringIfNull(txt_Episodes.Text, 0);

            Framework.repo.xml.AnimeRepository repo;
            repo = new Framework.repo.xml.AnimeRepository();
            try
            {
                repo.Add(anime);
                return true;
            }
            catch { return false; }
        }

        private bool isMangaType()
        {
            Manga item = new Manga();
            item.Name = txt_Name.Text;
            item.Favorite = chkBox_Favorite.Checked;

            item.Category = (MANGA_TYPE)Enum.Parse(typeof(MANGA_TYPE), cb_Category.SelectedValue + "");
            item.State = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), cb_State.SelectedValue + "");

            item.Comment = txt_Comment.Text;
            item.Rating = util.Expression.StringIfNull(txt_Rating.Text, 0);
            item.ChapterString = txt_Episodes.Text;

            Framework.repo.xml.MangaRepository repo;
            repo = new Framework.repo.xml.MangaRepository();
            try
            {
                repo.Add(item);
                return true;
            }
            catch { return false; }
        }

        internal void SetEntity(Type entityType)
        {
            this.entityType = entityType;

            switch (entityType.Name)
            {
                case "Anime":
                    cb_Category.DataSource = catalog.GetAnimeCategoriesTypes();
                    cb_Category.ValueMember = "Id";
                    cb_Category.DisplayMember = "Value";
                    break;
                case "Manga":
                    cb_Category.DataSource = catalog.GetMangaCategoriesTypes();
                    cb_Category.ValueMember = "Id";
                    cb_Category.DisplayMember = "Value";
                    break;
                default:
                    break;
            }
        }

        bool INewItem.ToRegisterItem()
        {
            switch (entityType.Name)
            {
                case "Anime":
                    return isAnimeType();
                case "Manga":
                    return isMangaType();
                default:
                    return false;
            }
        }

        bool ValidateInput()
        {
            //TODO: validate the input for new records.
            return true;
        }

        #endregion

    }
}
