﻿#pragma checksum "..\..\SelectLanguage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "938778F257167FCE6BD891A3AB304EE6F41ECBDF67773B83BCDDE373330FE0AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MultiLang {
    
    
    /// <summary>
    /// SelectLanguage
    /// </summary>
    public partial class SelectLanguage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\SelectLanguage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MultiLang.SelectLanguage Window1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\SelectLanguage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox GroupBox1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\SelectLanguage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbShow;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\SelectLanguage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbSelected;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\SelectLanguage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbDefault;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\SelectLanguage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOK;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Test;component/selectlanguage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectLanguage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window1 = ((MultiLang.SelectLanguage)(target));
            return;
            case 2:
            
            #line 34 "..\..\SelectLanguage.xaml"
            ((System.Windows.Controls.ListBox)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.btOK_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GroupBox1 = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 4:
            this.rbShow = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rbSelected = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbDefault = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.btOK = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\SelectLanguage.xaml"
            this.btOK.Click += new System.Windows.RoutedEventHandler(this.btOK_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
