using NetVision.AppWindows;
using NetVision.DataCore;
using NetVision.DataCore.Model;
using NetVision.Infrastructure;
using NetVision.Infrastructure.Files.FileTypes;
using NetVision.Infrastructure.Services;
using NetVision.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NetVision.ApplicationPages
{
    /// <summary>
    /// Logika interakcji dla klasy PingPage.xaml
    /// </summary>
    public partial class PingPage : Page
    {
        private PingViewModel vm;
        private IPingInfoService _service;

        public PingPage()
        {
            InitializeComponent();
            vm = new PingViewModel();
            DataContext = vm;
            saveFile.IsEnabled = false;
        }

        private void btnGetPing_Click(object sender, RoutedEventArgs e)
        {
            if(vm.PingInfoList != null && vm.PingInfoList.Count > 0)
                list.ItemsSource = vm.PingInfoList;
            saveFile.IsEnabled = true;
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            int avg_timeout = 0;
            int initial_timeout = 0;

            for(int i = 0; i < vm.Counts; ++i)
            {
                initial_timeout += vm.TTL;
            }
            if (vm.Counts != 0)
                avg_timeout = (initial_timeout / vm.Counts);
  
            string txtToSave = "Host: " + vm.Host + " adress: " + vm.Address + " Average timeout: " + avg_timeout + " ms" +
                " Data Length: " + vm.BufferLength + " bits ";

            List<string> attr = new List<string>();
            attr.Add(vm.Address);
            attr.Add(vm.BufferLength.ToString());
            attr.Add(vm.Host);
            attr.Add(vm.TTL.ToString());
            attr.Add(vm.Timeout.ToString());
            attr.Add(vm.Counts.ToString());
            SaveFileWindow sw = new SaveFileWindow(txtToSave);
            sw.Show();
        }
    }
}
