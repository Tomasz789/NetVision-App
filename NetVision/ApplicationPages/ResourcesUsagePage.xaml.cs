using NetVision.ApplicationPages.HardwarePages;
using NetVision.ApplicationPages.Panels;
using NetVision.ViewModel;
using System;
using System.Collections.Generic;
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

namespace NetVision.ApplicationPages
{
    /// <summary>
    /// Logika interakcji dla klasy ResourcesUsagePage.xaml
    /// </summary>
    public partial class ResourcesUsagePage : Page
    {
        private PerformanceValuesViewModel vm = new PerformanceValuesViewModel();
        public ResourcesUsagePage()
        {
            InitializeComponent();
            
            //list.Items.Add(vm.PerformanceModelList.ElementAt(vm.PerformanceModelList.Count - 1).RAM_Total_Usage.ToString());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           // vm = new PerformanceValuesViewModel();
            //DataContext = vm;
        }

        private void cpuUsageButton_Click(object sender, RoutedEventArgs e)
        {
            PerformanceValuesWindow win = new PerformanceValuesWindow();
            win.Show();
        }

        private void discUsageButton_Click(object sender, RoutedEventArgs e)
        {
            DriveInfoPage dIpage = new DriveInfoPage();
            resourcePagePanel.Content = dIpage;
        }

        private void ramUsageButton_Click(object sender, RoutedEventArgs e)
        {
            VisualizationPage dPanel = new VisualizationPage("RAMTOTAL");
            resourcePagePanel.Content = dPanel;
        }
    }
}
