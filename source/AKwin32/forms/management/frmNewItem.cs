using System;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.App.Forms.Management;
using AnimeKakkoi.App.Helpers;
using AnimeKakkoi.Core.Data.Json;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.Helpers;

namespace AnimeKakkoi.App.Forms.Management
{
    public partial class FrmNewItem : BaseToolbox, INewItem
    {

        private object _entity;

        private Type _entityType;

        private Catalog _catalog;

        public FrmNewItem()
        {
            InitializeComponent();
            _catalog = new Catalog();
        }

        #region GUI Events

        private void frmNewItem_Load(object sender, EventArgs e)
        {
            if (_entityType == null)
            {
                MessageHandler.ShowError(this, base.Errors["entity_missed"]);
                this.Close();
            }
            ((INewItem)this).DoVisualChanges();
        }

        private void txt_Rating_Validated(object sender, EventArgs e)
        {
            txt_Rating.Text = StringHelper.GetOnlyNumbers(txt_Rating.Text) + "";
            if (Convert.ToInt32(txt_Rating.Text) > 10)
                txt_Rating.Text = "10";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
                if (((INewItem)this).ToRegisterItem())
                {
                    MessageHandler.ShowInformation(this, base.Messages["item_affected"]);
                }
                else
                    MessageHandler.ShowError(this, base.Errors["items_error"]);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageHandler.ShowQuestion(this, base.Messages["exit_question"]);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        #endregion

        #region Functions

        void INewItem.DoVisualChanges()
        {
            txt_Progress.PromptChar = EntityProperties.EPISODE_EMPTYCHAR;
            cb_State.DataSource = Catalog.GetEntitiesStateTypes(Program.Language);
            cb_State.ValueMember = "Id";
            cb_State.DisplayMember = "Description";
        }

        private bool isAnimeType()
        {
            var item = new Anime();
            item.Name = txt_Name.Text;
            item.Favorite = chkBox_Favorite.Checked;

            item.Category = (AnimeType)Enum.Parse(typeof(AnimeType), cb_Category.SelectedValue + "");
            item.State = (EntityState)Enum.Parse(typeof(EntityState), cb_State.SelectedValue + "");

            item.Comment = txt_Comment.Text;
            item.Rating = StringHelper.IfIntegerNull(txt_Rating.Text, 0);
            item.ProgressString = StringHelper.IfStringNull(txt_Progress.Text, "0/0");

            try
            {
                using (var repo = new AnimeRepository())
                {
                    repo.Add(item);
                    _entity = item;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool isMangaType()
        {
            var item = new Manga();
            item.Name = txt_Name.Text;
            item.Favorite = chkBox_Favorite.Checked;

            item.Category = (MangaType)Enum.Parse(typeof(MangaType), cb_Category.SelectedValue + "");
            item.State = (EntityState)Enum.Parse(typeof(EntityState), cb_State.SelectedValue + "");

            item.Comment = txt_Comment.Text;
            item.Rating = StringHelper.IfIntegerNull(txt_Rating.Text, 0);
            item.ProgressString = txt_Progress.Text;

            MangaRepository repo = new MangaRepository();
            try
            {
                repo.Add(item);
                _entity = item;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetEntity(Type entityType)
        {
            this._entityType = entityType;

            switch (entityType.Name)
            {
                case "Anime":
                    cb_Category.DataSource = Catalog.GetAnimeCategoriesTypes();
                    break;
                case "Manga":
                    cb_Category.DataSource = Catalog.GetMangaCategoriesTypes();
                    break;
                default:
                    break;
            }
            cb_Category.ValueMember = "Id";
            cb_Category.DisplayMember = "Value";
        }

        bool INewItem.ToRegisterItem()
        {
            switch (_entityType.Name)
            {
                case "Anime":
                    return isAnimeType();
                case "Manga":
                    return isMangaType();
                default:
                    return false;
            }
        }

        private bool ValidateInput()
        {
            bool r = true;

            if (String.IsNullOrEmpty(txt_Name.Text))
                r = false;

            if (cb_Category.Text.Equals("--", StringComparison.InvariantCultureIgnoreCase) ||
                cb_State.Text.Equals("--", StringComparison.InvariantCultureIgnoreCase))
                r = false;

            return r;
        }

        #endregion

    }
}