using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Framework.entity;

namespace AKwin32.forms.management
{
    public partial class frmMgmtAnime : AKwin32.forms.management.frmManagement, IUIManagement
    {

        Framework.repo.xml.AnimeRepository repo;

        List<Anime> dataSource;

        public frmMgmtAnime()
        {
            InitializeComponent();
            this.Text = "Anime";
            entityType = typeof(Anime);
            repo = new Framework.repo.xml.AnimeRepository();
        }


        #region GUI Events

        protected override void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count < 1) return;
            Anime anime = listViewItems.SelectedItems[0].Tag as Anime;
            listViewItems.SelectedItems[0].Remove();
            repo.Remove(anime);

            string evt_change = " (-) " + anime.ToString();
            AKwin32.com.util.EventLogger.Write(Configuration.ApplicationLoggerFile, evt_change);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.Form_State != FORM_USING_STATE.EDITING)
                this.Close();
            //
            dataSource.Clear();
            foreach (ListViewItem item in listViewItems.Items)
                dataSource.Add(ObjectToType(item.Tag));
            ((IUIManagement)this).SaveItemsToRepository(false);
            //
            this.Close();
        }

        #endregion

        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            this.dataSource = OriginalDataSource.ConvertAll(
            new Converter<object, Anime>(ObjectToType));
        }

        void IUIManagement.DoVisualChanges()
        {
            btnRemoveItem.Click += new EventHandler(btnRemoveItem_Click);
            btnAccept.Click += new EventHandler(btnAccept_Click);

            base.FillComboBoxCatalog(cb_Category, Framework.io.Catalog.GetAnimeCategoriesTypes());
        }

        void IUIManagement.InheritControlSelection(System.Windows.Forms.Control ctrl, string pName, object entity)
        {

        }

        void IUIManagement.InheritControlValidation(Control ctrl, System.Reflection.PropertyInfo p, object entity)
        {
            if (p.PropertyType == typeof(ANIME_TYPE))
            {
                ANIME_TYPE s = (ANIME_TYPE)Enum.Parse(typeof(ANIME_TYPE), ctrl.Text);
                p.SetValue(entity, (int)s, null);
            }
        }

        void IUIManagement.LoadDataToControls()
        {
            ListViewItem item;
            foreach (Anime anime in this.dataSource)
            {
                item = new ListViewItem(new string[] { anime.Name, anime.ToString() });
                item.Tag = anime;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.PrepareDataFromRepo()
        {
            this.dataSource = repo.GetAll().ToList();
            OriginalDataSource = dataSource.ConvertAll(
            new Converter<Anime, object>(TypeToObject));
        }

        void IUIManagement.FilterData(List<object> list)
        {
            ListViewItem item;
            foreach (Anime anime in list)
            {
                item = new ListViewItem(new string[] { anime.Name, anime.ToString() });
                item.Tag = anime;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.setReadOnlyMode()
        {
            //throw new NotImplementedException();
        }

        void IUIManagement.SaveItemsToRepository(bool newItems)
        {
            int result;
            if (newItems)
                result = repo.AddRange(dataSource);
            else
                result = repo.Change(dataSource);

            if (result != dataSource.Count)
                base.ShowInformation(this,
                    base.Messages["items_saved"] + String.Format(" ({0})", result));

        }

        #endregion

        #region Functions

        private Anime ObjectToType(object obj)
        {
            return (Anime)obj;
        }

        private object TypeToObject(Anime item)
        {
            return (object)item;
        }

        #endregion

    }
}
