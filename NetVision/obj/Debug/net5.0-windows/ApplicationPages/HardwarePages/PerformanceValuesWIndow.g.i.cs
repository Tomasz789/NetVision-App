﻿#pragma checksum "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0853EF36F8957BFC6C06A84745A6807B4554E35E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using NetVision.ApplicationPages.HardwarePages;
using NetVision.ViewModel.Converters;
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


namespace NetVision.ApplicationPages.HardwarePages {
    
    
    /// <summary>
    /// PerformanceValuesWindow
    /// </summary>
    public partial class PerformanceValuesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame cpuPlot;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ramPlot;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labCPU;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labRAM;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labRamAv;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labRamCurr;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonChartSettings;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NetVision;component/applicationpages/hardwarepages/performancevalueswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
            ((NetVision.ApplicationPages.HardwarePages.PerformanceValuesWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cpuPlot = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.ramPlot = ((System.Windows.Controls.Frame)(target));
            return;
            case 4:
            this.labCPU = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.labRAM = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.labRamAv = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.labRamCurr = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.buttonChartSettings = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\..\ApplicationPages\HardwarePages\PerformanceValuesWindow.xaml"
            this.buttonChartSettings.Click += new System.Windows.RoutedEventHandler(this.buttonChartSettings_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

