using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.App.Helpers;
using AnimeKakkoi.Core.Entities;

namespace AnimeKakkoi.App.Forms.Management
{
    public partial class FrmManagement : Base
    {

        protected IEnumerable<object> OriginalDataSource;

        protected Catalog Catalog;

        protected Type EntityType;

        protected FrmManagement()
        {
            if (!(this is IUIManagement))
                throw new NotImplementedException("The Inherit class must implement IUIManagement interface.");

            InitializeComponent();
            Catalog = new Catalog();
        }

        #region GUI Events

        private void frmManagement_Load(object sender, EventArgs e)
        {
            _controlEnabled = true;
            AlternateControlsEnability();
            this.listViewItems.Resize += listViewItems_Resize;
            //
            foreach (Control ctrl in panel1.Controls)
                if (ctrl is TextBox || ctrl is ComboBox)
                    ctrl.Validated += this.guiField_Validated;

            if (this.Form_State == FormUsingState.Loaded)
                ((IUIManagement)this).setReadOnlyMode();

            else
                ((IUIManagement)this).PrepareDataFromRepo();

            this.LoadDataToControls();
            ((IUIManagement)this).LoadDataToControls();

            DoVisualChanges();
            ((IUIManagement)this).DoVisualChanges();
        }


        private void cbBoxItemType_SelectedValueChanged(object sender, EventArgs e)
        {
            var item = (filter_cbBoxItemType.SelectedItem as Catalog);
            if (item == null || OriginalDataSource == null)
                return;

            if (item.Description == "--")
            {
                listViewItems.Items.Clear();
                ((IUIManagement)this).LoadDataToControls();
            }
            else
            {
                listViewItems.Items.Clear();
                var state = (EntityState)Enum.Parse(typeof(EntityState), item.Id);
                ((IUIManagement)this).FilterData(
                    OriginalDataSource.Where(
                        c => (EntityState)c.GetType().GetProperty("State").GetValue(c, null) == state).ToList());
            }
        }

        private void listViewItems_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            listViewItems_Resize(sender, e);
        }

        private void listViewItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewItems.SelectedItems.Count < 0)
                return;

            ((IUIManagement)this).ShowItem(e.Item.Tag);
        }

        protected void guiField_Validated(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count <= 0) return;

            var ctrl = sender as Control;

            if (!ctrl.Name.Contains(CharacterNameSeparator)) return;

            ListViewItem item = listViewItems.SelectedItems[0];
            object entity = item.Tag;
            string name = ctrl.Name.Split(CharacterNameSeparator)[1];
            System.Reflection.PropertyInfo p = entity.GetType().GetProperty(name);

            string evt_change = " (c) " + entity.GetType().GetMethod("ToString").Invoke(entity, null) + " to ";

            if (ctrl is ComboBox)
            {
                if (p.PropertyType == typeof(EntityState))
                {
                    var s = (EntityState)Enum.Parse(typeof(EntityState), (ctrl as ComboBox).SelectedValue + "");
                    p.SetValue(entity, (int)s, null);
                }
                else //Sends to inherits class for check out.
                {
                    ((IUIManagement)this).InheritControlValidation(ctrl, p, entity);
                }
            }
            else if (ctrl is Label)
            {
                p.SetValue(entity, Convert.ChangeType(_favoriteIndicator, p.PropertyType), null);
            }
            else if (p == null) // if P = null, this property must be unique
            {
                ((IUIManagement)this).InheritControlValidation(ctrl, p, entity);
            }
            else
                p.SetValue(entity, Convert.ChangeType(ctrl.Text, p.PropertyType), null);

            item.Tag = entity;
            item.SubItems[1] = new ListViewItem.ListViewSubItem(item,
                                                                entity.GetType()
                                                                      .GetMethod("ToString")
                                                                      .Invoke(entity, null) + "");
            listViewItems.Items[listViewItems.SelectedItems[0].Index] = item;

            // save a log
            evt_change += entity.GetType().GetMethod("ToString").Invoke(entity, null);
            //EventLogger.Write(AnimeKakkoi.App.IO.AppAkConfiguration.AppLoggerFile, evt_change);
        }

        private void lblFavorite_Click(object sender, EventArgs e)
        {
            AlternateFavoriteControl();
            guiField_Validated(sender, e);
        }

        protected virtual void btnRemoveItem_Click(object sender, EventArgs e)
        { }

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
            this.groupBox1.Text = EntityType.Name + "s";
            this.listViewItems.Resize += this.listViewItems_Resize;
            this.filter_cbBoxItemType.SelectedValueChanged += cbBoxItemType_SelectedValueChanged;

            //--AlternateControlsEnability();
        }

        public void LoadDataToControls()
        {
            base.FillComboBoxCatalog(filter_cbBoxItemType, Catalog.GetEntitiesStateTypes(Program.Language));

            base.FillComboBoxCatalog(cb_State, Catalog.GetEntitiesStateTypes());
        }

        public void PrepareDataFromRepo()
        {
        }

        public void FilterData(List<object> list)
        {
        }

        public void SetReadOnlyMode()
        {
            throw new NotImplementedException();
        }

        public void SaveItemsToRepository()
        {
            throw new NotImplementedException();
        }

        #endregion

        private bool _controlEnabled;

        protected void AlternateControlsEnability()
        {
            foreach (Control ctrl in this.panel1.Controls)
            {
                ctrl.Enabled = _controlEnabled;
            }
            _controlEnabled = !_controlEnabled;
        }

        private bool _favoriteIndicator;

        protected void AlternateFavoriteControl()
        {
            _favoriteIndicator = !_favoriteIndicator;
            AlternateFavoriteControl(_favoriteIndicator);
        }

        protected void AlternateFavoriteControl(bool favoriteIndicator)
        {
            lbl_Favorite.Image = favoriteIndicator ? Properties.Resources.fav_media : Properties.Resources.fav_no_media;
        }


        internal void SetItemsList(IEnumerable<object> source, Type type)
        {
            this.EntityType = type;
            this.OriginalDataSource = source;
            this.Form_State = FormUsingState.Loaded;
            ((IUIManagement)this).ConvertItemsToDefaultType();
            ((IUIManagement)this).SaveItemsToRepository(true);
        }

        #endregion

    }
}