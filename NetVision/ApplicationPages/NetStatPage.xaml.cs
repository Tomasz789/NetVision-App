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
    /// Logika interakcji dla klasy NetStatPage.xaml
    /// </summary>
    public partial class NetStatPage : Page
    {
        public NetStatPage()
        {
            InitializeComponent();
        }

        private void NetworkInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new NetworkInformationPage();
            NetPagePanel.Content = page;
        }

        private void TcpConnectionPage_Click(object sender, RoutedEventArgs e)
        {
            var page = new NetStatConnectionPage();
            NetPagePanel.Content = page;
        }

        private void ProcessPage_Click(object sender, RoutedEventArgs e)
        {
            var page = new ProcessPage();
            NetPagePanel.Content = page;
        }
    }
}
