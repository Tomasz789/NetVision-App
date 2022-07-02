using NetVision.ApplicationPages.HardwarePages.Plot;
using NetVision.AppWindows;
using NetVision.Infrastructure.Services;
using NetVision.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NetVision.ApplicationPages.HardwarePages
{
    /// <summary>
    /// Logika interakcji dla klasy PerformanceValuesWIndow.xaml
    /// </summary>
    public partial class PerformanceValuesWindow : Window
    {
        private readonly PerformanceValuesViewModel _vm;
        int i = 0;
        private IPerformanceService serv;
        private delegate void SetLabelValueFromDataContext(float value);
        public PerformanceValuesWindow()
        {
            InitializeComponent();
            _vm = new PerformanceValuesViewModel();
            DataContext = _vm;
           // var dt = new DispatcherTimer();
           // dt.Interval = TimeSpan.FromSeconds(1);
            serv = new PerformanceService();
           

           /* Task.Factory.StartNew(() =>
            {
                SetValues();
            });*/
        }

        private void SetValues(float value)
        {
            DataContext = _vm;
            _vm.GetValues();
            labCPU.Content = Math.Round(_vm.CPU_Usage,2).ToString();
            labRAM.Content = Math.Round((_vm.RAM_Total_Usage/1.024E+06),2).ToString();
            labRamAv.Content = Math.Round(_vm.RAM_Available,2).ToString();
            labRamCurr.Content = Math.Round(_vm.RAM_Current,2).ToString();
        }

        private void DoWork()
        {
            while (true)
            {
                Dispatcher.BeginInvoke(
                    new SetLabelValueFromDataContext(SetValues), new object[] { 1 });
                Thread.Sleep(1000);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChartView viewCPU = new ChartView(DataCore.PerformanceValueTypes.PerformanceValueType.CPU);
            cpuPlot.Content = viewCPU;
            ChartView viewRAM = new ChartView(DataCore.PerformanceValueTypes.PerformanceValueType.RAM_AVAILABLE);
            ramPlot.Content = viewRAM;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                DoWork();
            }).Start();
        }

        private void buttonChartSettings_Click(object sender, RoutedEventArgs e)
        {
            var window = new ChartSettingsWindow();
            window.Show();
        }
    }
}
