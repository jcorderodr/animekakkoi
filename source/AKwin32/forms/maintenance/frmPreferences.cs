using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AKwin32.Properties;

namespace AKwin32.forms.maintenance
{
    public partial class frmPreferences : AKwin32.forms.frmBaseToolbox
    {

        Settings setts = Properties.Settings.Default;

        public frmPreferences()
        {
            InitializeComponent();
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            panelColorSample.BackColor = setts.frmBackGroundColor;
            linkLabelFontColor.LinkColor = setts.UiFontsColor;

            linkLabelFontsStyle.Font = setts.UiFontsStyles;
            linkLabelControlsStyle.Font = setts.UiControlsFontsStyle;
        }

        private void linkLabelColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                panelColorSample.BackColor = colorDialog.Color;
            }
        }

        private void linkLabelFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                linkLabelFontColor.LinkColor = colorDialog.Color;
            }
        }

        private void linkLabelControlsStyle_Click(object sender, EventArgs e)
        {
            fontDialog.Font = linkLabelControlsStyle.Font;
            if (fontDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                linkLabelControlsStyle.Font = fontDialog.Font;
            }
        }

        private void linkLabelFontsStyle_Click(object sender, EventArgs e)
        {
            fontDialog.Font = linkLabelFontsStyle.Font;
            if (fontDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                linkLabelFontsStyle.Font = fontDialog.Font;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            SaveChanges();
            this.Close();
        }

        private void SaveChanges()
        {
            setts.frmBackGroundColor = panelColorSample.BackColor;
            setts.UiFontsStyles = linkLabelFontsStyle.Font;
            setts.UiFontsColor = linkLabelFontColor.LinkColor;
            setts.UiControlsFontsStyle = linkLabelControlsStyle.Font;

            setts.Save();
        }


    }
}
