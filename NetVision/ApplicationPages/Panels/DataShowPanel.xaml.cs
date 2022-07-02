using NetVision.DataCore.PerformanceValueTypes;
using NetVision.ViewModel;
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

namespace NetVision.ApplicationPages.Panels
{
    /// <summary>
    /// Logika interakcji dla klasy DataShowPanel.xaml
    /// </summary>
    public partial class DataShowPanel : Page
    {
        private PerformanceValuesViewModel vm = new PerformanceValuesViewModel();
        private Stopwatch timer = new Stopwatch();
        private DispatcherTimer dt = new DispatcherTimer();
        private PerformanceValueType _perfType;
        public DataShowPanel(PerformanceValueType type)
        {
            InitializeComponent();
            _perfType = type;
            /*DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1000);
            dt.Tick += timer_Tick;
            dt.Start();*/

            //timer.Start();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += ShowValueWithInterval;
            dt.Start();
            DataContext = vm;
        }

        private async void ShowValueWithInterval(object sender, EventArgs e)
        {
           // Task.Factory.StartNew(Show_Value);
           // await vm.GetValues(_perfType);
            //var res = Math.Round(vm.GetModel().CPU_Usage,2);
          //  valuePanel.Text = res.ToString();
            //Console.WriteLine(res);
        }

        private async Task Show_Value()
        {

            /*valuePanel.Text = vm.PerformanceModelList.ElementAt(
                vm.PerformanceModelList.Count - 1).CPU_Usage.ToString();*/
           // while (timer.IsRunning)
            //{
                //if (timer.ElapsedMilliseconds == TimeSpan.FromMilliseconds(1000))
               // {
                    //await vm.GetValues(PerformanceValueType.CPU);
                    //valuePanel.Text = vm.GetModel().CPU_Usage.ToString();
                   // timer.Reset();
                    await Task.CompletedTask;
                //}
                
           // }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
