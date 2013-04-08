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
            entityType = typeof(Anime);
            repo = new Framework.repo.xml.AnimeRepository();
        }

        #region IUIManagement

        void IUIManagement.ConvertItemsToDefaultType()
        {
            this.dataSource = OriginalDataSource.ConvertAll(
            new Converter<object, Anime>(ObjectToType));
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
            foreach (Anime anime in this.dataSource)
            {
                item = new ListViewItem(new string[] { anime.Name, anime.Category + "" });
                item.Tag = anime;
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
            foreach (Anime anime in list)
            {
                item = new ListViewItem(new string[] { anime.Name, anime.Category + "" });
                item.Tag = anime;
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

        private Anime ObjectToType(object obj)
        {
            return (Anime)obj;
        }

        #endregion
    }
}
