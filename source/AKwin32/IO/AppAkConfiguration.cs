#region

using System;
using System.Drawing;

#endregion

namespace AnimeKakkoi.App.IO
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AppAkConfiguration : Core.IO.AkConfiguration
    {
        
        #region Application

        internal static String ApplicationBasePath
        {
            get { return ApplicationDataFolder; }
        }

        internal static String ProductUrl
        {
            get { return GetSetting("ApplicationProductUrl"); }
        }

        #endregion

        #region User

        internal static System.Globalization.CultureInfo ApplicationCulture
        {
            get { return new System.Globalization.CultureInfo(GetSetting("UserCultureLanguage")); }
        }

        internal static Font UiControlsFontStyle
        {
            get { return new Font(GetSetting("UserUiControlsFontsStyle"), 9); }
        }

        internal static Font UiFontsStyle
        {
            get { return new Font(GetSetting("UserUiFontsStyles"), 9); }
        }

        internal static Color UiFontsColor
        {
            get
            {
                var value = GetSetting("UserUiFontsColor");
                return Color.FromName(value);
            }
        }

        internal static bool UserUsingInstantSearch
        {
            get
            {
                var value = GetSetting("UserInstantSearch");
                return Convert.ToBoolean(value);
            }
        }

        #endregion
    }
}