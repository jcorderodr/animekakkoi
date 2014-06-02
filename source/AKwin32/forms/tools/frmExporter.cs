using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnimeKakkoi.App.Forms;
using AnimeKakkoi.Core.Entities;
using AnimeKakkoi.Core.IO;
using AnimeKakkoi.Core.Lang;


namespace AnimeKakkoi.App.Forms.tools
{
    public partial class FrmExporter : BaseToolbox
    {
        private List<object> _elements;

        public FrmExporter()
        {
            InitializeComponent();

            _elements = new List<object>();
        }

        private void frmExporter_Load(object sender, EventArgs e)
        {
            saveFileDialog.Title = Program.APP_TITLE;
            //saveFileDialog.Filter = FileProperties.AppSharingFileFilterName;

            List<Catalog> cbValues = Catalog.GetEntitiesValidTypes();

            int id = Convert.ToInt32(cbValues.LastOrDefault().Id) + 1;
            cbValues.Add(new Catalog {Id = id + "", Description = "by own"});

            base.FillComboBoxCatalog(cb_OptionOutputState, cbValues);
        }

        private void btnDoSelection_Click(object sender, EventArgs e)
        {
            var frm = new frmItemSelector();
            DialogResult result = frm.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                _elements = frm.UserSelection;
                Analize();
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            if (DoOperation())
                base.ShowInformation(this, base.Messages[LanguageExpressions.OPERATION_SUCESS]);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Analize()
        {
            lblItemsSelected.Text = _elements.Count + "";
        }

        public void SetProperties(string title)
        {
            this.Text = title;
        }

        private bool DoOperation()
        {
            var state = cb_OptionOutputState.SelectedItem as Catalog;

            FileManager mgr;
            //mgr = new FileManager(saveFileDialog.FileName);
            //try
            //{
            //    mgr.ElementState = (EntityState) Enum.Parse(typeof (EntityState), state.Value);
            //}
            //catch
            //{
            //}
            //mgr.Elements = elements;
            //mgr.Save();
            this.progressBar.Value = 100;

            return true;
        }
    }
}