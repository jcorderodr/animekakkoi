﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AKwin32.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("255, 255, 192")]
        public global::System.Drawing.Color frmBackGroundColor {
            get {
                return ((global::System.Drawing.Color)(this["frmBackGroundColor"]));
            }
            set {
                this["frmBackGroundColor"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://corderoski.wordpress.com/bluegletek-soft/animekakkoi/")]
        public string ApplicationProductUrl {
            get {
                return ((string)(this["ApplicationProductUrl"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Comic Sans MS, 9pt, style=Bold")]
        public global::System.Drawing.Font UiFontsStyles {
            get {
                return ((global::System.Drawing.Font)(this["UiFontsStyles"]));
            }
            set {
                this["UiFontsStyles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DimGray")]
        public global::System.Drawing.Color UiFontsColor {
            get {
                return ((global::System.Drawing.Color)(this["UiFontsColor"]));
            }
            set {
                this["UiFontsColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Arial Narrow, 9pt, style=Bold")]
        public global::System.Drawing.Font UiControlsFontsStyle {
            get {
                return ((global::System.Drawing.Font)(this["UiControlsFontsStyle"]));
            }
            set {
                this["UiControlsFontsStyle"] = value;
            }
        }
    }
}
