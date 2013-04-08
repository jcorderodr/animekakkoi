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
    public partial class frmManagement : AKwin32.forms.frmBase, IUIManagement
    {

        protected List<object> OriginalDataSource;

        protected Catalog catalog;

        protected Type entityType;

        public frmManagement()
        {
            InitializeComponent();
            catalog = new Catalog();
        }


        #region GUI Events

        private void frmManagement_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Validated += new System.EventHandler(this.guiField_Validated);
            }
            //
            if (this.Form_State == FORM_USING_STATE.LOADED)
            {
                ((IUIManagement)this).setReadOnlyMode();
            }
            else
            {
                ((IUIManagement)this).PrepareDataFromRepo();
            }

            ((IUIManagement)this).DoVisualChanges();

            ((IUIManagement)this).LoadDataToControls();
        }

        private void listViewItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item == null)
                return;
        }

        protected void listViewItems_Resize(object sender, EventArgs e)
        {
            SizeLastColumn(sender as ListView);
        }

        private void cbBoxItemType_SelectedValueChanged(object sender, EventArgs e)
        {
            string item = (cbBoxItemType.SelectedItem as Catalog).Value;
            if (item == "--") return;
            listViewItems.Items.Clear();
            ENTITY_STATE state = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), item);
            ((IUIManagement)this).FilterData(OriginalDataSource.Where(c => (ENTITY_STATE)c.GetType().GetProperty("State").GetValue(c, null) == state).ToList());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OriginalDataSource = null;
            this.Close();
        }

        protected void guiField_Validated(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count <= 0) return;

            Control ctrl = sender as Control;

            object item = listViewItems.SelectedItems[0].Tag;
            string name = ctrl.Name.Split('_')[1];
            System.Reflection.PropertyInfo p = item.GetType().GetProperty(name);

            if (ctrl.GetType() == typeof(ComboBox))
            {
                ENTITY_STATE s = (ENTITY_STATE)Enum.Parse(typeof(ENTITY_STATE), ctrl.Text);
                p.SetValue(item, (int)s, null);
            }
            else
                p.SetValue(item, Convert.ChangeType(ctrl.Text, p.PropertyType), null);

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
            //throw new NotImplementedException();
        }

        public void LoadDataToControls()
        {
            //throw new NotImplementedException();
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


        bool usedColorIndicator;
        protected Color GetAlternateItemColor()
        {
            if (usedColorIndicator)
            {
                usedColorIndicator = !usedColorIndicator;
                return Color.AliceBlue;
            }
            else
            {
                usedColorIndicator = !usedColorIndicator;
                return Color.AntiqueWhite;
            }
        }

        internal void SetItemsList(List<object> source, Type type)
        {
            this.entityType = type;
            this.OriginalDataSource = source;
            this.Form_State = FORM_USING_STATE.LOADED;
            ((IUIManagement)this).ConvertItemsToDefaultType();
            ((IUIManagement)this).SaveItemsToRepository();
        }

        protected void SizeLastColumn(ListView lv)
        {
            listViewItems.Columns[listViewItems.Columns.Count - 1].Width = -2;
        }

        #endregion






    }
}
