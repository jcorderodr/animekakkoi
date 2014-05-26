#region

using System;

#endregion

namespace AnimeKakkoi.App.IO
{
    public class CommandLine
    {
        private System.Windows.Forms.IWin32Window parent;

        private String[] input;


        private COMMAND_ACTION cmd;
        private string file;

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
                    var mgr = new Framework.util.FileManager(file);
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