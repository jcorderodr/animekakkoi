#region

using System;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.App.Forms.Management;
using AnimeKakkoi.Core.Data;
using AnimeKakkoi.Core.Entities;

#endregion

namespace AnimeKakkoi.App.Forms.Management
{
    public partial class frmEntityEdit : BaseToolbox
    {
        private object repo;

        private Type entityType;
        private object entityContent;

        private bool favoriteIndicator;

        public frmEntityEdit()
        {
            InitializeComponent();
        }

        #region UI Events

        private void frmEntityEdit_Load(object sender, EventArgs e)
        {
            base.FillComboBoxCatalog(cb_State, Catalog.GetEntitiesValidTypes());

            if (entityType.Name == typeof (Anime).Name)
            {
                base.FillComboBoxCatalog(cb_Category, Catalog.GetAnimeCategoriesTypes());
            }
            else if (entityType.Name == typeof (Manga).Name)
            {
                base.FillComboBoxCatalog(cb_Category, Catalog.GetMangaCategoriesTypes());
            }

            LoadItem();
        }

        private void guiField_Validated(object sender, EventArgs e)
        {
            var ctrl = sender as Control;

            if (!ctrl.Name.Contains(CharacterNameSeparator + "")) return;

            string name = ctrl.Name.Split(CharacterNameSeparator)[1];
            System.Reflection.PropertyInfo p = entityContent.GetType().GetProperty(name);

            if (ctrl is ComboBox)
            {
                if (p.PropertyType == typeof (EntityState))
                {
                    var s = (EntityState) Enum.Parse(typeof (EntityState), ctrl.Text);
                    p.SetValue(entityContent, (int) s, null);
                }
                else //Sends to inherits class for check out.
                {
                    ((IUIManagement) this).InheritControlValidation(ctrl, p, entityContent);
                }
            }
            else if (ctrl is Label)
            {
                p.SetValue(entityContent, Convert.ChangeType(favoriteIndicator, p.PropertyType), null);
            }
            else if (p == null) // if P = null, this property must be unique
            {
                //             
            }
            else
            {
                if (name == "Episodes" || name == "Chapters")
                    p = entityContent.GetType().GetProperty("ProgressString");

                p.SetValue(entityContent, Convert.ChangeType(ctrl.Text, p.PropertyType), null);
            }

            this.Form_State = FormUsingState.Editing;
        }

        private void lbl_Favorite_MouseClick(object sender, MouseEventArgs e)
        {
            favoriteIndicator = !favoriteIndicator;
            if (favoriteIndicator)
                lbl_Favorite.Image = AnimeKakkoi.App.Properties.Resources.fav_media;
            else
                lbl_Favorite.Image = AnimeKakkoi.App.Properties.Resources.fav_no_media;
            guiField_Validated(sender, e);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string repoNameType = entityContent.GetType().Name;
            if (entityType.Name == typeof (Anime).Name)
            {
                ((IRepository<Anime>) repo).Change(entityContent as Anime);
            }
            else if (entityType.Name == typeof (Manga).Name)
            {
                ((IRepository<Manga>) repo).Change(entityContent as Manga);
            }
            else if (entityType.Name == typeof (EntitySource).Name)
            {
                ((IRepository<EntitySource>) repo).Change(entityContent as EntitySource);
            }
            else
            {
                AnimeKakkoi.App.Helpers.MessageHandler.ShowError(this, base.Errors["save_method_unknown"]);
                return;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Functions

        protected void AlternateFavoriteControl(bool favoriteIndicator)
        {
            if (favoriteIndicator)
                lbl_Favorite.Image = AnimeKakkoi.App.Properties.Resources.fav_media;
            else
                lbl_Favorite.Image = AnimeKakkoi.App.Properties.Resources.fav_no_media;
        }

        private void LoadItem()
        {
            foreach (Control ctrl in this.panel1.Controls)
            {
                if (!ctrl.Name.Contains(CharacterNameSeparator + "")) continue;

                string name = ctrl.Name.Split('_')[1];
                System.Reflection.PropertyInfo p = entityContent.GetType().GetProperty(name);

                if (p == null) // if P = null, this property must be unique
                {
                    continue;
                }
                if (ctrl is Label) // if lbl is Favorite
                {
                    favoriteIndicator = bool.Parse(p.GetValue(entityContent, null).ToString());
                    AlternateFavoriteControl(favoriteIndicator);
                    continue;
                }
                if (ctrl is ComboBox)
                {
                    (ctrl as ComboBox).Text = p.GetValue(entityContent, null).ToString();
                    continue;
                }
                if (name == "Episodes" || name == "Chapters")
                {
                    p = entityContent.GetType().GetProperty("ProgressString");
                }
                ctrl.Text = p.GetValue(entityContent, null).ToString();
            }
        }

        public void SetEntityObject(object entity)
        {
            entityContent = entity;
        }

        public void SetRepository(IRepository<Anime> repo)
        {
            entityType = repo.RepositoryType();
            this.repo = repo;
        }

        public void SetRepository(IRepository<Manga> repo)
        {
            entityType = repo.RepositoryType();
            this.repo = repo;
        }

        public void SetRepository(IRepository<EntitySource> repo)
        {
            entityType = repo.RepositoryType();
            this.repo = repo;
        }

        #endregion
    }
}