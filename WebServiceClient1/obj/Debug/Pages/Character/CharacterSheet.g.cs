﻿#pragma checksum "..\..\..\..\Pages\Character\CharacterSheet.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "08BC405817024335EFD35AFF9C16C86B"
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
using DnDServicePlayer.Pages.Character.Selection;
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
    /// CharacterSheet
    /// </summary>
    public partial class CharacterSheet : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stat_button;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button special_button;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button inventory_button;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button spellbook_button;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button adventure_button;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button discussion_button;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button option_button;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_button;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer sheet_controllers;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
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
            System.Uri resourceLocater = new System.Uri("/DnDServicePlayer;component/pages/character/charactersheet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
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
            this.stat_button = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.stat_button.Click += new System.Windows.RoutedEventHandler(this.change_page);
            
            #line default
            #line hidden
            return;
            case 2:
            this.special_button = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.special_button.Click += new System.Windows.RoutedEventHandler(this.change_page);
            
            #line default
            #line hidden
            return;
            case 3:
            this.inventory_button = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.inventory_button.Click += new System.Windows.RoutedEventHandler(this.change_page);
            
            #line default
            #line hidden
            return;
            case 4:
            this.spellbook_button = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.spellbook_button.Click += new System.Windows.RoutedEventHandler(this.change_page);
            
            #line default
            #line hidden
            return;
            case 5:
            this.adventure_button = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.adventure_button.Click += new System.Windows.RoutedEventHandler(this.change_page);
            
            #line default
            #line hidden
            return;
            case 6:
            this.discussion_button = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.discussion_button.Click += new System.Windows.RoutedEventHandler(this.change_page);
            
            #line default
            #line hidden
            return;
            case 7:
            this.option_button = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.option_button.Click += new System.Windows.RoutedEventHandler(this.change_page);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cancel_button = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\Pages\Character\CharacterSheet.xaml"
            this.cancel_button.Click += new System.Windows.RoutedEventHandler(this.cancel_button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.sheet_controllers = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 10:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

