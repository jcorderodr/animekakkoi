#region

using System;
using System.Drawing;

#endregion

namespace AnimeKakkoi.App.IO
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AppAkConfiguration : Framework.IO.AkConfiguration
    {
        #region Application

        internal static String ApplicationBasePath
        {
            get { return ApplicationDataFolder; }
        }

        internal static String ApplicationLoggerFile
        {
            get { return ApplicationBasePath + "usr-h.log"; }
        }

        internal static String ApplicationProgressMask
        {
            get { return GetSetting("ApplicationEntityProgressMask"); }
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

        internal static Color FormBackGroundColor
        {
            get
            {
                var text = GetSetting("UserfrmBackGroundColor");

                var values = text.Split(',');
                return Color.FromArgb(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
            }
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