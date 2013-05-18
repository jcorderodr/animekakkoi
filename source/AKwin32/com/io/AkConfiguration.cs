using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AKwin32.Properties;

namespace AKwin32.com.io
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AkConfiguration
    {

        public Color FormBackGroundColor { get { return setts.frmBackGroundColor; } }

        public String ProductUrl { get { return setts.ApplicationProductUrl; } }

        /// <summary>
        /// Gets all the settings.
        /// </summary>
        static Settings setts = Properties.Settings.Default;

    }
}
