using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AKwin32.com.io
{
    public class CommandLine
    {

        System.Windows.Forms.IWin32Window parent;

        String[] input;

        String processedInput;

        public CommandLine()
        {


        }

        public void SetProperties(System.Windows.Forms.IWin32Window parent, string[] input)
        {
            this.parent = parent;
            this.input = input;
        }

        private void AnalyzeInput()
        {
            //TODO: analyze command-line input
        }


        public void ExecActions()
        {
            AnalyzeInput();


            forms.management.frmImporter frm = new forms.management.frmImporter();
            frm.Show(parent);
        }
    }
}
