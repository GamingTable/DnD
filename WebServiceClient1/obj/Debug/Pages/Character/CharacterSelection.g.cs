﻿#pragma checksum "..\..\..\..\Pages\Character\CharacterSelection.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "84F2E831EFD7B167E61D061522C5D553"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using DnDServicePlayer.Pages;
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


namespace DnDServicePlayer.Pages {
    
    
    /// <summary>
    /// CharacterSelection
    /// </summary>
    public partial class CharacterSelection : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button select_button;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button create_button;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox characters_list;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_button;
        
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
            System.Uri resourceLocater = new System.Uri("/DnDServicePlayer;component/pages/character/characterselection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
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
            this.select_button = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
            this.select_button.Click += new System.Windows.RoutedEventHandler(this.select_button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.create_button = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
            this.create_button.Click += new System.Windows.RoutedEventHandler(this.create_button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.characters_list = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.cancel_button = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Pages\Character\CharacterSelection.xaml"
            this.cancel_button.Click += new System.Windows.RoutedEventHandler(this.cancel_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

