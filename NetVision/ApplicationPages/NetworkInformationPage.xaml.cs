using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
using NetVision.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Logika interakcji dla klasy NetworkInformationPage.xaml
    /// </summary>
    public partial class NetworkInformationPage : Page
    {
        private INetworkingInfoService _service = new NetworkingInfoService();
        private NetInfoViewModel vm = new NetInfoViewModel();
        private IList<NetworkInfoModel> cardList;
        private List<Button> buttonList;
        private Button button;
        private TextBlock buttonLabel;
        private StackPanel innerPanel;

        public NetworkInformationPage()
        {
            InitializeComponent();
            FindNetworkCards();
            SetGeneralNetworkInformation();
            DataContext = vm;
        }

        //------------------set host name, domain name and internet state
        private void SetGeneralNetworkInformation()
        {
            txtDomain.Text = _service.GetDomainName();
            txtHost.Text = _service.GetHostName();
            var internet_state = _service.GetInternetState();   //get internet state
            if (internet_state)
            {
                statusLight.Fill = Brushes.Green;       //if connected
                txtNet.Foreground = Brushes.Green;
                txtNet.Text = "Connected";
            }
            else
            {
                statusLight.Fill = Brushes.Red;
                txtNet.Foreground = Brushes.Red;
                txtNet.Text = "Disconnected";
            }

            txtHost.Text = _service.GetHostName();  //get host name
            txtDomain.Text = _service.GetDomainName();  //get domain
        }

        private void FindNetworkCards()
        {
            var brush = new SolidColorBrush(Color.FromRgb(64, 64, 64));

            buttonList = new List<Button>();
            string path = "";
            int cnt = vm.NetworkInfos.Count();
            for(int i=0; i < vm.NetworkInfos.Count(); ++i)
            {
                button = new Button();
                buttonLabel = new TextBlock();
                innerPanel = new StackPanel();
                innerPanel.Width = 120;
                innerPanel.Height = 150;
                innerPanel.Orientation = Orientation.Vertical;
              

                if (vm.NetworkInfos.ElementAt(i).Name.Contains("Wi-Fi"))
                    path = "/ApplicationPages/wifiIcon.png";
                else path = "/ApplicationPages/iconNormal.png";

                button.Name = "cardInfoButton" + i.ToString();
                button.Content = new Image
                {
                    Source = new BitmapImage(new Uri(path, UriKind.Relative)),
                    Stretch = Stretch.Fill,
        
                };
                buttonLabel.Width = 90;
                buttonLabel.Height = 60;
                buttonLabel.TextWrapping = TextWrapping.Wrap;
                buttonLabel.Foreground = Brushes.White;
                buttonLabel.FontSize = 10;
                buttonLabel.Text =  vm.NetworkInfos.ElementAt(i).Name;
                button.Width = 90;
                button.Height = 100;
                button.Click += new RoutedEventHandler(cardButtonClicked);

                innerPanel.Children.Add(button);
                innerPanel.Children.Add(buttonLabel);
                button.Background = brush;
                buttonsPanel.Children.Add(innerPanel);
                buttonList.Add(button);
            }
        }

        private void SetCardInformation(NetworkInfoModel card)
        {
            List<TreeViewItem> trees = new List<TreeViewItem>();
            for(int i=0; i<6;++i)
            {
                var cardInfo = new TreeViewItem();
                cardInfo.Name = "CardInfo" + i.ToString();      //create new tree view item with name card + iteration
                trees.Add(cardInfo);    //add to trees list
            }

            trees.ElementAt(0).Header = card.Id;
            trees.ElementAt(1).Header = card.Name;
            trees.ElementAt(2).Header = card.Description;
            trees.ElementAt(3).Header = card.Speed;
            trees.ElementAt(4).Header = card.Status;

            trvCardId.Items.Add(trees.ElementAt(0));
        }

        private void cardButtonClicked(object sender, RoutedEventArgs e)
        {
            FrameworkElement current_button;

            for(int i=0; i<buttonList.Count(); ++i)
            {
                current_button = e.Source as FrameworkElement;  //create new fe
                if(current_button.Name == buttonList.ElementAt(i).Name)
                {
                    DisplayNetworkInformation(vm.NetworkInfos.ElementAt(i).Name);   //if fe name equals button name display info
                }
            }
            
            e.Handled = true;
        }
    //---------------add dns, gateways and dhcp addresses to treeview-------------------
        private void AddAddresses(TreeViewItem item, List<string> addr) 
        {

            if (addr is null)
                throw new Exception("Error");

            if (addr.Count <= 0)
                MessageBox.Show("Cannot get addresses list");

            foreach(var i in addr)
            {
                var itemView = new TreeViewItem();
                itemView.Header = i;
                item.Items.Add(itemView);
                
            }

        }
        private void DisplayNetworkInformation(string name)
        {
            var card = _service.GetInterfaceByName(name);//vm.NetworkInfos.FirstOrDefault(r => r.Name == name); //get card by name
            cardList = new List<NetworkInfoModel>();

            cardList.Add(card);
            this.DataContext = cardList;    //set data context

            AddAddresses(trvGateways, card.GatewayAddresses);       //set values
            AddAddresses(trvDhcp, card.DhcpAddresses);
            AddAddresses(trvDns, card.DnsAddresses);

        }
    }
}
