﻿#pragma checksum "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09C9EFC782F36B1A85E0C0ED784C5C7810AEF2CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using NetVision.ApplicationPages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace NetVision.ApplicationPages {
    
    
    /// <summary>
    /// ResourcesUsagePage
    /// </summary>
    public partial class ResourcesUsagePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generalButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cpuUsageButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ramUsageButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button discUsageButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button infoButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame resourcePagePanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NetVision;component/applicationpages/resourcesusagepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
            ((NetVision.ApplicationPages.ResourcesUsagePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.generalButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.cpuUsageButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
            this.cpuUsageButton.Click += new System.Windows.RoutedEventHandler(this.cpuUsageButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ramUsageButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
            this.ramUsageButton.Click += new System.Windows.RoutedEventHandler(this.ramUsageButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.discUsageButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\ApplicationPages\ResourcesUsagePage.xaml"
            this.discUsageButton.Click += new System.Windows.RoutedEventHandler(this.discUsageButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.infoButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.resourcePagePanel = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

