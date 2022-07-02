using NetVision.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetVision
{
    /// <summary>
    /// Logika interakcji dla klasy NetStatConnectionPage.xaml
    /// </summary>
    public partial class NetStatConnectionPage : Page
    {
        private readonly NetStatViewModel _vm;
        //private readonly IEnumerable<>
        public NetStatConnectionPage()
        {
            InitializeComponent();
            _vm = new NetStatViewModel();
            txtSearch.IsEnabled = false;
            DataContext = _vm;
        }


        private void btnShowConnections_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.IsEnabled = true;
            connectionList.ItemsSource = _vm.TcpInfoList;   //set itemssource to listview
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(connectionList.ItemsSource);
            view.Filter = SearchByElement;
        }

        private bool SearchByElement(object element)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                return true;
            else
                return ((element as TcpConnectionInformation).RemoteEndPoint.ToString().IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(connectionList.ItemsSource).Refresh();  //refersh view
        }

        private void btnShowUdpConnections_Click(object sender, RoutedEventArgs e)
        {
            UdpconnectionList.ItemsSource = _vm.UdpInfoList;    //set itemssource to listview
        }

        private void txtUdpSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
