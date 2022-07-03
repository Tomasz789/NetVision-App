using LiveCharts;
using NetVision.AppWindows;
using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services.HardwareServ;
using NetVision.Infrastructure.Services.ProcessService;
using NetVision.Infrastructure.Services.ProcessService.Types;
using NetVision.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NetVision.ApplicationPages.HardwarePages
{
    /// <summary>
    /// Logika interakcji dla klasy DriveInfoPage.xaml
    /// </summary>
    public partial class DriveInfoPage : Page
    {
        private DriveInfoViewModel vm;
        private IDriveService _serv;
        private IList<DriveModel> _list;
        private ChartValues<float> _val;
        
        public DriveInfoPage()
        {
            InitializeComponent();
            vm = new DriveInfoViewModel();
            DataContext = vm;
            _serv = new DriveService();
            ///Task.Factory.StartNew(GetDriveValuesFromVm);
            showdrivers();
            saveFileButton.Click += new RoutedEventHandler(SaveFile);
            driveCmb.SelectionChanged += new SelectionChangedEventHandler(ShowValuesOnPanel);
            PointLabel = chartPoint =>
                    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
        }

        /// <summary>
        /// Method allows save a .txt file with drive space informations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFile(object sender, RoutedEventArgs e)
        {
            string txt = "";
            if(driveInfoListPanel.Items.Count > 0)
            {
                foreach (var drive in vm.DriveModelList)
                {
                    txt += "Drive " + drive.Name+ " format: " + drive.Format + " free space: "
                        + drive.AvailableSpace.ToString() + " MB " + " total size: " + drive.TotalSpace.ToString() + " MB" + " \n";
                }
            }
            else
            {
                MessageBox.Show("Cannot get drive data!");
            }
            SaveFileWindow sWindow = new SaveFileWindow(txt);
            sWindow.Show();
        }

        private void ShowValuesOnPanel(object sender, RoutedEventArgs e)
        {
            string current_drive_name = driveCmb.SelectedValue.ToString();
            _list = new List<DriveModel>();
            var dr = vm.GetSelectedDriveModel(current_drive_name).Result;
            //_val = new ChartValues<float>();
            //_val.Add(0);
            //lvcFreeSpace.
             lvcFreeSpace.Values = _val;
            lvcTotalSpace.Values = _val;
             _list.Add(dr);
            driveInfoListPanel.ItemsSource = _list;
            /*_val = new ChartValues<float>();
            _val.Add(dr.AvailableSpace);*/
            // _val.Add(dr.TotalSpace);
            //DataContext = _list;
            
            gV_Name.DisplayMemberBinding = new Binding("Name");
            gv_Format.DisplayMemberBinding = new Binding("Format");
            gv_Space_Av.DisplayMemberBinding = new Binding("AvailableSpace");
            gv_Space_Total.DisplayMemberBinding = new Binding("TotalSpace");
            lvcFreeSpace.Values = vm.AvailableSpaceList;
            lvcTotalSpace.Values = vm.TotalSpaceList;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }
        private async Task GetDriveValuesFromVm()
        {
            await vm.ProcessValues();
            var list = _serv.GetDrivers().Result;
            // for(int i=0; i<list.Count; ++i)
            /*foreach(var drive in DriveInfo.GetDrives())
                 driveCmb.Items.Add(drive.Name);*/

            foreach (var drive in vm.DriveModelList)
                driveCmb.Items.Add(drive.Name);

        }

        private void showdrivers()
        {
            vm.ProcessValues().ConfigureAwait(true);
            foreach (var drive in vm.DriveModelList)
                driveCmb.Items.Add(drive.Name);
        }

        private void buttonCleaner_Click(object sender, RoutedEventArgs e)
        {
            var cleanerLaunch = new ProcessLauncher(ProcessTypes.CLEANMGR);
            cleanerLaunch.LaunchProcess();
        }
    }
}
