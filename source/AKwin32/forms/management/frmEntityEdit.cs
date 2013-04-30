using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.repo;
using Framework.entity;
using Framework.io;

namespace AKwin32.forms.management
{
    public partial class frmEntityEdit : AKwin32.forms.frmBaseToolbox
    {

        object repo;

        Type entityType;
        object entityContent;

        bool favoriteIndicator;

        public frmEntityEdit()
        {
            InitializeComponent();

        }

        #region UI Events 

        private void frmEntityEdit_Load(object sender, EventArgs e)
        {
            base.FillComboBoxCatalog(cb_State, Catalog.GetEntitiesStateTypes());

            if (entityType.Name == typeof(Anime).Name)
            {
                base.FillComboBoxCatalog(cb_Category, Catalog.GetAnimeCategoriesTypes());
            }
            else if (entityType.Name == typeof(Manga).Name)
            {
                base.FillComboBoxCatalog(cb_Category, Catalog.GetMangaCategoriesTypes());
            }
            //--else if (entityType.Name == typeof(EntitySource).Name)
            //--{
            //--    base.FillComboBoxCatalog(cb_Category, Catalog.GetEntitiesValidTypes());
            //--}
           
            LoadItem();
        }

        private void guiField_Validated(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;

            if (!ctrl.Name.Contains(CharacterNameSeparator + "")) return;

            string name = ctrl.Name.Split(CharacterNameSeparator)[1];
            System.Reflection.PropertyInfo p = entityContent.GetType().GetProperty(name);

            if (ctrl is ComboBox)
            {
                if (p.PropertyType == typeof(ENTITY_STATE))
                {
                    ENTITY_STATE s = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), ctrl.Text);
                    p.SetValue(entityContent, (int)s, null);
                }
                else //Sends to inherits class for check out.
                {
                    ((IUIManagement)this).InheritControlValidation(ctrl, p, entityContent);
                }
            }
            else if (ctrl is Label)
            {
                p.SetValue(entityContent, Convert.ChangeType(favoriteIndicator, p.PropertyType), null);
            }
            else if (p == null) // if P = null, this property must be unique
            {
                Manga manga = entityContent as Manga;
                if (name == "Episodes")
                {
                    string[] values = Framework.util.Expression.GetOnlyNumbersText(ctrl.Text).Split('/');
                    p = entityContent.GetType().GetProperty("Chapters");
                    p.SetValue(entityContent, values, null);
                }
            }
            else
                p.SetValue(entityContent, Convert.ChangeType(ctrl.Text, p.PropertyType), null);


            this.Form_State = FORM_USING_STATE.EDITING;
        }

        private void lbl_Favorite_MouseClick(object sender, MouseEventArgs e)
        {
            favoriteIndicator = !favoriteIndicator;
            if (favoriteIndicator)
                lbl_Favorite.Image = Properties.Resources.fav_media;
            else
                lbl_Favorite.Image = Properties.Resources.fav_no_media;
            guiField_Validated(sender, e);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string repoNameType = entityContent.GetType().Name;
            if (entityType.Name == typeof(Anime).Name)
            {
                ((IRepository<Anime>)repo).Change(entityContent as Anime);
            }
            else if (entityType.Name == typeof(Manga).Name)
            {
                ((IRepository<Manga>)repo).Change(entityContent as Manga);
            }
            else if (entityType.Name == typeof(EntitySource).Name)
            {
                ((IRepository<EntitySource>)repo).Change(entityContent as EntitySource);
            }
            else
            {
                base.ShowError(this, base.Errors["save_method_unknown"]);
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
                lbl_Favorite.Image = Properties.Resources.fav_media;
            else
                lbl_Favorite.Image = Properties.Resources.fav_no_media;
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
                    Manga manga = entityContent as Manga;
                    if (name == "Episodes")
                    {
                        p = entityContent.GetType().GetProperty("Chapters");
                        ctrl.Text = manga.ChapterString;
                    }
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
