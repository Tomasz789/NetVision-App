using NetVision.DataCore.Model;
using NetVision.Utilities;
using NetVision.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetVision.ApplicationPages
{
    /// <summary>
    /// Logika interakcji dla klasy TraceRoutePage.xaml
    /// </summary>
    public partial class TraceRoutePage : Page
    {
        private IEnumerable<TraceEntryModel> traceEntryModels = new List<TraceEntryModel>();
        private TraceRouteViewModel vm;
        private List<TraceEntryModel> _model;

        private delegate void SetListViewModel(float set);
        private delegate void SetProgressRing(bool isActive);
        public TraceRoutePage()
        {
            InitializeComponent();
            vm = new TraceRouteViewModel();
            _model = new List<TraceEntryModel>();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            btnStart.Click += new RoutedEventHandler(StartReading);
            btnStop.Click += new RoutedEventHandler(StopReading);
            DataContext = vm;
        }

        private void StopReading(object sender, RoutedEventArgs e)
        {
            SpinProgressRing(false);
            int sum = 0;
            if (_model is null)
                MessageBox.Show("Error", "Invalid data cannot obtain tracert results!");

            foreach(var item in _model)
            {
                sum += Convert.ToInt16(item.Timeout);
            }

            float avg = sum / _model.Count;
            vm.AvgTimeout = (int)avg;
            long minTimeout;
            long maxTimeout ;

            foreach(var item in _model)
            {
                /*if (minTimeout < item.MinTimeout)
                    minTimeout = item.MinTimeout;*/
            }
        }

        private void StartReading(object sender, RoutedEventArgs e)
        {
            /*new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                DoWork();
            }).Start();*/
            Task.Run(FillListView);
        }

        private async Task FillListView()
        {
            //var res = await vm.GetTracert();
           // viewMainPanel.ItemsSource = res;
            ////hopColumn.DisplayMemberBinding = new Binding("HopCounter");
            //addrColumn.DisplayMemberBinding = new Binding("Address");
            //await Task.Delay(1000);
        }

        private void SpinProgressRing(bool isActive)
        {
            if (isActive)
                progRing.IsActive = true;
            else progRing.IsActive = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void DoWork()
        {
            foreach(var item in vm.TraceList)
            {
                Dispatcher.BeginInvoke(
                    new SetListViewModel(SetData), new object[] { 1 });
                Thread.Sleep(1000);
            }
        }

        private async void SetData(float set)
        {
             //vm.GetTracert();
            SpinProgressRing(true);
            //_model.Add(res);
           /* viewMainPanel.ItemsSource = vm.TraceList;
            hopColumn.DisplayMemberBinding = new Binding("HopCounter");
            hostColumn.DisplayMemberBinding = new Binding("HostName");
            addrColumn.DisplayMemberBinding = new Binding("Address");
            timeoutColumn.DisplayMemberBinding = new Binding("Timeout");*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = vm.ObservableTraceList;
           // MessageBox.Show(items.Count.ToString());
            viewMainPanel.ItemsSource = items;
        }
    }
}
