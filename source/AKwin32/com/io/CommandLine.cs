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


        COMMAND_ACTION cmd;
        string file;

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
            if (input[0] == "-f")
            {
                file = input[1];
                cmd = COMMAND_ACTION.OPEN_FILE;
            }
        }


        public void ExecActions()
        {
            AnalyzeInput();

            switch (cmd)
            {
                case COMMAND_ACTION.OPEN_FILE:
                    Framework.util.FileManager mgr = new Framework.util.FileManager(file);
                    mgr.Load();
                    //mgr.Elements
                    break;
                default:
                    break;
            }

        }
    }

    public enum COMMAND_ACTION
    {
        OPEN_FILE = 1
    }

}
