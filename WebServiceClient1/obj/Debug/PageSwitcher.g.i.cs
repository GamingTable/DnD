﻿#pragma checksum "..\..\PageSwitcher.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0D6708EC9CE5875EA48A53A9CFF1F93D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using DnDServiceClient;
using DnDServicePlayer;
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


namespace DnDServiceClient {
    
    
    /// <summary>
    /// PageSwitcher
    /// </summary>
    public partial class PageSwitcher : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logo_display;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button about_button;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reduce_button;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close_button;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock welcome_display;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.UserControl Container;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock infobar;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\PageSwitcher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DnDServicePlayer.AboutUs aboutUs;
        
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
            System.Uri resourceLocater = new System.Uri("/DnDServicePlayer;component/pageswitcher.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageSwitcher.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 25 "..\..\PageSwitcher.xaml"
            ((System.Windows.Controls.DockPanel)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DraggableWindow_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.logo_display = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.about_button = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\PageSwitcher.xaml"
            this.about_button.Click += new System.Windows.RoutedEventHandler(this.about_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.reduce_button = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\PageSwitcher.xaml"
            this.reduce_button.Click += new System.Windows.RoutedEventHandler(this.reduce_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.close_button = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\PageSwitcher.xaml"
            this.close_button.Click += new System.Windows.RoutedEventHandler(this.close_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.welcome_display = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Container = ((System.Windows.Controls.UserControl)(target));
            return;
            case 8:
            this.infobar = ((System.Windows.Controls.TextBlock)(target));
            
            #line 37 "..\..\PageSwitcher.xaml"
            this.infobar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DraggableWindow_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.aboutUs = ((DnDServicePlayer.AboutUs)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

