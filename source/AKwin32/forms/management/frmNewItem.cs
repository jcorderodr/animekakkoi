using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.entity;
using Framework.io;
using Framework.util;

namespace AKwin32.forms.management
{
    public partial class frmNewItem : AKwin32.forms.frmBaseToolbox, INewItem
    {

        Type entityType;

        Framework.io.Catalog catalog;

        public frmNewItem()
        {
            InitializeComponent();
            catalog = new Catalog();
            //
        }

        #region GUI Events

        private void frmNewItem_Load(object sender, EventArgs e)
        {
            if (entityType == null)
            {
                base.ShowError(this, base.Errors["entity_missed"]);
                this.Close();
            }
            ((INewItem)this).DoVisualChanges();
        }

        private void txt_Episodes_Validated(object sender, EventArgs e)
        {
            txt_Episodes.Text = Expression.GetOnlyNumbersText(txt_Episodes.Text);
        }

        private void txt_Rating_Validated(object sender, EventArgs e)
        {
            txt_Rating.Text = Expression.GetOnlyNumbers(txt_Rating.Text) + "";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
                if (((INewItem)this).ToRegisterItem())
                {
                    base.ShowInformation(this, base.Messages["item_affected"]);
                    base.CleanUIComponents();
                }
                else
                    base.ShowError(this, base.Errors["items_error"]);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = base.ShowQuestion(this, base.Messages["exit_question"]);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        #endregion

        #region Functions


        void INewItem.DoVisualChanges()
        {
            cb_State.DataSource = Catalog.GetEntitiesTypesByLanguage();
            cb_State.ValueMember = "Id";
            cb_State.DisplayMember = "Description";
        }

        private bool isAnimeType()
        {
            Anime anime = new Anime();
            anime.Name = txt_Name.Text;
            anime.Favorite = chkBox_Favorite.Checked;

            anime.Category = (ANIME_TYPE)Enum.Parse(typeof(ANIME_TYPE), cb_Category.SelectedValue + "");
            anime.State = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), cb_State.SelectedValue + "");

            anime.Comment = txt_Comment.Text;
            anime.Rating = Expression.IntegerIfNull(txt_Rating.Text, 0);
            anime.ProgressString = Expression.StringIfNull(txt_Episodes.Text, "0/0");

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
            item.Rating = Expression.IntegerIfNull(txt_Rating.Text, 0);
            //if doesnt cotains '/' it ends 01/?, otherwise x/y
            item.ProgressString = txt_Episodes.Text.Contains("/") ? txt_Episodes.Text : txt_Episodes.Text + "/?";

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
                    cb_Category.DataSource = Catalog.GetAnimeCategoriesTypes();
                    cb_Category.ValueMember = "Id";
                    cb_Category.DisplayMember = "Value";
                    break;
                case "Manga":
                    cb_Category.DataSource = Catalog.GetMangaCategoriesTypes();
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
