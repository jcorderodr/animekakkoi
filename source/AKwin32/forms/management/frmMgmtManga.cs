using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Framework.repo.xml;
using Framework.entity;

namespace AKwin32.forms.management
{
    public partial class frmMgmtManga : AKwin32.forms.management.frmManagement, IUIManagement
    {

        List<Manga> dataSource;

        MangaRepository repo;

        public frmMgmtManga()
        {
            InitializeComponent();
            entityType = typeof(Manga);
            repo = new MangaRepository();
        }


        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            this.dataSource = OriginalDataSource.ConvertAll(
            new Converter<object, Manga>(ObjectToType));
        }

        void IUIManagement.DoVisualChanges()
        {
            cbBoxItemType.DataSource = catalog.GetEntitiesStateTypes();
            cbBoxItemType.ValueMember = "Id";
            cbBoxItemType.DisplayMember = "Value";
        }

        void IUIManagement.LoadDataToControls()
        {
            ListViewItem item;
            foreach (Manga manga in this.dataSource)
            {
                item = new ListViewItem(new string[] { manga.Name, manga.Category + "" });
                item.Tag = manga;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.PrepareDataFromRepo()
        {
            this.dataSource = repo.GetAll().ToList();
        }

        void IUIManagement.FilterData(List<object> list)
        {
            ListViewItem item;
            foreach (Manga manga in list)
            {
                item = new ListViewItem(new string[] { manga.Name, manga.Category + "" });
                item.Tag = manga;
                item.BackColor = GetAlternateItemColor();
                listViewItems.Items.Add(item);
            }
        }

        void IUIManagement.setReadOnlyMode()
        {
            //throw new NotImplementedException();
        }

        void IUIManagement.SaveItemsToRepository()
        {
            int result = repo.AddRange(dataSource);
            if (result != dataSource.Count)
                MessageBox.Show(this, "just saved " + result, Program.AppTitle);
        }

        #endregion

        #region Functions

        private Manga ObjectToType(object obj)
        {
            return (Manga)obj;
        }

        #endregion

    }
}
