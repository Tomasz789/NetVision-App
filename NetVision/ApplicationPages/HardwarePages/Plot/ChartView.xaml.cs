using LiveCharts;
using NetVision.DataCore.Model;
using NetVision.DataCore.PerformanceValueTypes;
using NetVision.Infrastructure.Services;
using NetVision.ViewModel.Plot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NetVision.ApplicationPages.HardwarePages.Plot
{
    /// <summary>
    /// Logika interakcji dla klasy ChartView.xaml
    /// </summary>
    public partial class ChartView : Page
    {
        private ChartViewModel vm;
        private IPerformanceService _service;
        private DispatcherTimer _dt;
        private Stopwatch stopWatch;
        private PerformanceValueType _type;
        long t = 0;
        private object chartsettingsWindow;

        public ChartView(PerformanceValueType type)
        {
            InitializeComponent();
            buttonStart.Click += new RoutedEventHandler(StartPlotting);
            buttonStop.Click += new RoutedEventHandler(StopPlot);
            _type = type;
            vm = new ChartViewModel();
            stopWatch = new Stopwatch();
            _dt = new DispatcherTimer();
            _service = new PerformanceService();
            DataContext = vm;
            vm.ConfigureChart();
        }

        private void StopPlot(object sender, RoutedEventArgs e)
        {
            _dt.Stop();
            stopWatch.Stop();
            Console.WriteLine(vm.ChartValues.Count);
        }

        private void StartPlotting(object sender, RoutedEventArgs e)
        {
            _dt.Interval = TimeSpan.FromSeconds(1);
            _dt.Tick += MeasureValue;
            _dt.Start();
            stopWatch.Start();
        }

        private async void MeasureValue(object sender, EventArgs e)
        {
            DataContext = vm;
           
            float y;
            ++t;
            switch (_type)
            {
                case PerformanceValueType.CPU:
                    y = await _service.CPU_MeasureUsage();
                    break;
                case PerformanceValueType.RAM_AVAILABLE:
                    y = await _service.RAM_Available();
                    break;
                default:
                    throw new ArgumentException(nameof(_type),"Invalid argument type! CPU and RAM_AVAILABLE can be used.");
            }
            var tt = stopWatch.ElapsedMilliseconds;
            var time = new DateTime(tt);
            vm.PlotValues(y,DateTime.Now);
        }

    }
}
