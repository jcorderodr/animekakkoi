using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AKwin32.forms.tools
{
    public partial class frmExporter : AKwin32.forms.frmBaseToolbox
    {

        List<object> elements;

        public frmExporter()
        {
            InitializeComponent();

            elements = new List<object>();
        }

        private void frmExporter_Load(object sender, EventArgs e)
        {
            saveFileDialog.Title = Program.AppTitle;
            saveFileDialog.Filter = Framework.io.FileProperties.AppSharingFileFilterName;

            List<Framework.io.Catalog> cbValues = Framework.io.Catalog.GetEntitiesTypesByLanguage();

            int id = Convert.ToInt32(cbValues.LastOrDefault().Id) + 1;
            cbValues.Add(new Framework.io.Catalog() { Id = id + "", Description = "by own" });

            base.FillComboBoxCatalog(cb_OptionOutputState, cbValues);
        }

        private void btnDoSelection_Click(object sender, EventArgs e)
        {
            frmItemSelector frm = new frmItemSelector();
            DialogResult result = frm.ShowDialog(this);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                elements = frm.UserSelection;
                Analize();
            }
        }


        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (saveFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            Framework.io.Catalog state = cb_OptionOutputState.SelectedItem as Framework.io.Catalog;

            Framework.util.FileManager mgr;
            mgr = new Framework.util.FileManager(saveFileDialog.FileName);
            mgr.Elements = elements;
            mgr.Save();

            base.ShowInformation(this, base.Messages[Framework.io.LanguageExpressions.OPERATION_SUCESS]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Analize()
        {
            lblItemsSelected.Text = elements.Count + "";
        }

        public void SetProperties(string title)
        {
            this.Text = title;
        }

    }
}
