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
        public global::System.Drawing.Color UserfrmBackGroundColor {
            get {
                return ((global::System.Drawing.Color)(this["UserfrmBackGroundColor"]));
            }
            set {
                this["UserfrmBackGroundColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Comic Sans MS, 9pt, style=Bold")]
        public global::System.Drawing.Font UserUiFontsStyles {
            get {
                return ((global::System.Drawing.Font)(this["UserUiFontsStyles"]));
            }
            set {
                this["UserUiFontsStyles"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DimGray")]
        public global::System.Drawing.Color UserUiFontsColor {
            get {
                return ((global::System.Drawing.Color)(this["UserUiFontsColor"]));
            }
            set {
                this["UserUiFontsColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Arial Narrow, 9pt, style=Bold")]
        public global::System.Drawing.Font UserUiControlsFontsStyle {
            get {
                return ((global::System.Drawing.Font)(this["UserUiControlsFontsStyle"]));
            }
            set {
                this["UserUiControlsFontsStyle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("en-US")]
        public string UserCultureLanguage {
            get {
                return ((string)(this["UserCultureLanguage"]));
            }
            set {
                this["UserCultureLanguage"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://bluegletek.com/products/animekakkoi.aspx")]
        public string ApplicationProductUrl {
            get {
                return ((string)(this["ApplicationProductUrl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://bluegletek.com/bws/ak_metadata.xml")]
        public string ApplicationMetadataUrl {
            get {
                return ((string)(this["ApplicationMetadataUrl"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ApplicationFirstRunning {
            get {
                return ((bool)(this["ApplicationFirstRunning"]));
            }
            set {
                this["ApplicationFirstRunning"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://sourceforge.net/p/animekakkoi/tickets/new/")]
        public string ApplicationBugReport {
            get {
                return ((string)(this["ApplicationBugReport"]));
            }
            set {
                this["ApplicationBugReport"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UserInstantSearch {
            get {
                return ((bool)(this["UserInstantSearch"]));
            }
            set {
                this["UserInstantSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("990/99#")]
        public string ApplicationEntityProgressMask {
            get {
                return ((string)(this["ApplicationEntityProgressMask"]));
            }
            set {
                this["ApplicationEntityProgressMask"] = value;
            }
        }
    }
}
