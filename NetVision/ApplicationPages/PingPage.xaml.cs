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
        private List<PingModel> _pingInfoList;

        public PingPage()
        {
            InitializeComponent();

            FillComponents();
            _service = new PingInfoService();
            vm = new PingViewModel(_service);
            DataContext = vm;
            saveFile.IsEnabled = false;
        }

        private void FillComponents()
        {
            //fill counts combobox
            //for (int i = 1; i <= 4; ++i)
              //  cmbCounts.Items.Add(i);
            //cmbCounts.SelectedIndex = 3;
        }

        private void btnGetPing_Click(object sender, RoutedEventArgs e)
        {
            PingOptions options = new PingOptions();

            // _service.SendPing(ipAddTxt.Text, Encoding.ASCII.GetBytes("aaaa"), Convert.ToInt32(timeoutTxt.Text), options);
            // _pingInfoList.Add(vm.PingInfo);
            /*list.Items.Add("Adres: " + vm.PingInfo.Address.ToString() + " czas: " + vm.PingInfo.Timeout.ToString()
                + "ms" + "TTL: "+ " wielkosć danych: " + "vm.BufferLength.ToString()");*/
        
            if(vm.PingInfoList != null && vm.PingInfoList.Count > 0)
                list.ItemsSource = vm.PingInfoList;
            saveFile.IsEnabled = true;
            //list.Items.Add(vm.PingInfoList.ElementAt(0).Address);
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            var text_builder = new StringBuilder();
            int cnt = list.Items.Count;
            int avg_timeout = 0;
            int initial_timeout = 0;

            for(int i = 0; i < vm.Counts; ++i)
            {
                initial_timeout += vm.TTL;
            }
            if (vm.Counts != 0)
                avg_timeout = (int)(initial_timeout / vm.Counts);
  
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
