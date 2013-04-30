using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework.repo;
using Framework.io;
using Framework.entity;

namespace AKwin32.forms.management
{
    public abstract partial class frmManagement : AKwin32.forms.frmBase//, IUIManagement
    {
        

        protected List<object> OriginalDataSource;

        protected Catalog catalog;

        protected Type entityType;

        public frmManagement()
        {
            if (!(this is IUIManagement))
                throw new NotImplementedException("The Inherit class must implements IUIManagement.");

            InitializeComponent();
            catalog = new Catalog();
        }


        #region GUI Events

        void frmManagement_Load(object sender, EventArgs e)
        {
            this.listViewItems.Resize += new System.EventHandler(listViewItems_Resize);
            foreach (Control ctrl in panel1.Controls)
                if (ctrl is TextBox || ctrl is ComboBox)
                    ctrl.Validated += new System.EventHandler(this.guiField_Validated);

            if (this.Form_State == FORM_USING_STATE.LOADED)
                ((IUIManagement)this).setReadOnlyMode();

            else
                ((IUIManagement)this).PrepareDataFromRepo();

            ((IUIManagement)this).DoVisualChanges();

            this.LoadDataToControls();
            ((IUIManagement)this).LoadDataToControls();
        }

        void cbBoxItemType_SelectedValueChanged(object sender, EventArgs e)
        {
            string item = (cbBoxItemType.SelectedItem as Catalog).Value;
            if (item == "--" || OriginalDataSource == null) return;
            listViewItems.Items.Clear();
            ENTITY_STATE state = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), item);
            ((IUIManagement)this).FilterData(OriginalDataSource.Where(c => (ENTITY_STATE)c.GetType().GetProperty("State").GetValue(c, null) == state).ToList());
        }
        
        void listViewItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item == null)
            {
                CleanUIComponents();
                return;
            }

            object item = e.Item.Tag;

            foreach (Control ctrl in this.panel1.Controls)
            {
                if (!ctrl.Name.Contains(CharacterNameSeparator)) continue;

                string name = ctrl.Name.Split('_')[1];
                System.Reflection.PropertyInfo p = item.GetType().GetProperty(name);

                if (p == null) // if P = null, this property must be unique
                {
                    ((IUIManagement)this).InheritControlSelection(ctrl, name, item);
                    continue;
                }
                if (ctrl is Label) // if lbl is Favorite
                {
                    favoriteIndicator = bool.Parse(p.GetValue(item, null).ToString());
                    AlternateFavoriteControl(favoriteIndicator);
                    continue;
                }
                if (ctrl is ComboBox)
                {
                    (ctrl as ComboBox).Text = p.GetValue(item, null).ToString();
                    continue;
                }
                ctrl.Text = p.GetValue(item, null).ToString();
            }
        }

        protected void guiField_Validated(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count <= 0) return;

            Control ctrl = sender as Control;

            if (!ctrl.Name.Contains(CharacterNameSeparator)) return;

            ListViewItem item = listViewItems.SelectedItems[0];
            object entity = item.Tag;
            string name = ctrl.Name.Split(CharacterNameSeparator)[1];
            System.Reflection.PropertyInfo p = entity.GetType().GetProperty(name);

            if (ctrl is ComboBox)
            {
                if (p.PropertyType == typeof(ENTITY_STATE))
                {
                    ENTITY_STATE s = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), ctrl.Text);
                    p.SetValue(entity, (int)s, null);
                }
                else //Sends to inherits class for check out.
                {
                    ((IUIManagement)this).InheritControlValidation(ctrl, p, entity);
                }
            }
            else if (ctrl is Label)
            {
                p.SetValue(entity, Convert.ChangeType(favoriteIndicator, p.PropertyType), null);
            }
            else if (p == null) // if P = null, this property must be unique
            {
                ((IUIManagement)this).InheritControlValidation(ctrl, p, entity);
            }
            else
                p.SetValue(entity, Convert.ChangeType(ctrl.Text, p.PropertyType), null);

            item.Tag = entity;
            item.SubItems[1] = new ListViewItem.ListViewSubItem(item, entity.GetType().GetProperty("Category").GetValue(entity, null) + "");
            listViewItems.Items[listViewItems.SelectedItems[0].Index] = item;

            this.Form_State = FORM_USING_STATE.EDITING;
        }

        private void lblFavorite_Click(object sender, EventArgs e)
        {
            AlternateFavoriteControl();
            guiField_Validated(sender, e);
        }

        protected abstract void btnRemoveItem_Click(object sender, EventArgs e);

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OriginalDataSource = null;
            this.Close();
        }

        #endregion

        #region Functions

        #region Virtual/IUIManagement Functions

        public void ConvertItemsToDefaultType()
        {
            throw new NotImplementedException();
        }

        public void DoVisualChanges()
        {
            this.listViewItems.Resize += new EventHandler(this.listViewItems_Resize);
        }

        public void LoadDataToControls()
        {
            base.FillComboBoxCatalog(cbBoxItemType, Catalog.GetEntitiesStateTypes());

            base.FillComboBoxCatalog(cb_State, Catalog.GetEntitiesStateTypes());
        }

        public void PrepareDataFromRepo()
        {
            //throw new NotImplementedException();
        }

        public void FilterData(List<object> list)
        {
            //throw new NotImplementedException();
        }

        public void setReadOnlyMode()
        {
            throw new NotImplementedException();
        }

        public void SaveItemsToRepository()
        {
            throw new NotImplementedException();
        }

        #endregion

        bool favoriteIndicator;
        protected void AlternateFavoriteControl()
        {
            favoriteIndicator = !favoriteIndicator;
            AlternateFavoriteControl(favoriteIndicator);
        }

        protected void AlternateFavoriteControl(bool favoriteIndicator)
        {
            if (favoriteIndicator)
                lbl_Favorite.Image = Properties.Resources.fav_media;
            else
                lbl_Favorite.Image = Properties.Resources.fav_no_media;
        }


        internal void SetItemsList(List<object> source, Type type)
        {
            this.entityType = type;
            this.OriginalDataSource = source;
            this.Form_State = FORM_USING_STATE.LOADED;
            ((IUIManagement)this).ConvertItemsToDefaultType();
            ((IUIManagement)this).SaveItemsToRepository(true);
        }


        #endregion





    }
}
