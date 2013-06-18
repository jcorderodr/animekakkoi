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

        #region Application

        public String ProductUrl { get { return setts.ApplicationProductUrl; } }

        public String ApplicationLoggerFile { get { return System.Windows.Forms.Application.StartupPath + System.IO.Path.DirectorySeparatorChar + "usr-h.log"; } }

        public String ApplicationProgressMask { get { return setts.ApplicationEntityProgressMask; } }


        #endregion


        #region User

        public System.Globalization.CultureInfo ApplicationCulture { get { return new System.Globalization.CultureInfo(setts.UserCultureLanguage); } }

        public Color FormBackGroundColor { get { return setts.UserfrmBackGroundColor; } }

        public Font UiControlsFontStyle { get { return setts.UserUiControlsFontsStyle; } }

        public Font UiFontsStyle { get { return setts.UserUiFontsStyles; } }

        public Color UiFontsColor { get { return setts.UserUiFontsColor; } }

        public bool UserUsingInstantSearch { get { return setts.UserInstantSearch; } }

        #endregion


        /// <summary>
        /// Gets all the settings.
        /// </summary>
        static Settings setts = Properties.Settings.Default;

    }
}
