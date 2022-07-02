using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NetVision.AppWindows
{
    /// <summary>
    /// Logika interakcji dla klasy TcpClientWindow.xaml
    /// </summary>
    public partial class TcpClientWindow : Window
    {
        private SocketService _service;
       
        private BackgroundWorker connectionThread;
        private BackgroundWorker readingThread;
        private string address_to_connect;
        private int port_to_connect;
        private DispatcherTimer dt;
        private IList<TextBlock> infoTextBlockList;
        private IList<FrameworkElement> object_list;
        private delegate void SetTerminalText(ListBox console, string text);
        private delegate void SetInfoTextBlockValue(TextBlock txtBlock, string text, int color);
        
        public TcpClientWindow()
        {
            InitializeComponent();
            _service = new TcpService();
            buttonConnect.Click += new RoutedEventHandler(TcpClientConnected);
            buttonDisConnect.Click += new RoutedEventHandler(DisconnectConnection);
            buttonSend.Click += new RoutedEventHandler(SendMessage);
            connectionThread = new BackgroundWorker();
            readingThread = new BackgroundWorker();
            connectionThread.DoWork += ConnectionThread_DoWork;
            readingThread.WorkerSupportsCancellation = true;
            readingThread.DoWork += ReceiveThread_DoWork;
            object_list = new List<FrameworkElement>();
            buttonDisConnect.IsEnabled = false;
            buttonSend.IsEnabled = false;
        }



        private void ConnectionThread_DoWork(object sender, DoWorkEventArgs e)
        {
            int attempts = 0;
            
            while(!SocketModel.IsConnected)
            {
                _service.StartConnection(address_to_connect, port_to_connect);
                ++attempts;
                if (attempts >= 3 || SocketModel.IsConnected == true)
                    break;
            }
            SetText(consoleInfo, SocketModel.InfoMsg);

            if (connectionThread.CancellationPending)
                e.Cancel = true;
            readingThread.RunWorkerAsync();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var res = _service.ReceiveData();
            readingThread.RunWorkerAsync();
        }

        private void ReceiveThread_DoWork(object sender, DoWorkEventArgs e)
        {
            //_service.StartConnection(address_to_connect, port_to_connect);
            string res = "";
            while (SocketModel.IsConnected)
            {
                res = _service.ReceiveData();
                if (!string.IsNullOrEmpty(res))
                    FillInfoPanel();
                SetText(tcpTerminal,res);
                Received_Done();
                Thread.Sleep(500);
        
            }
            SocketModel.IsConnected = true;
        }

        private void FillInfoPanel()
        {
            if (readingThread.IsBusy)
                readingThread.CancelAsync();
            //SetInfoText(object_list.SingleOrDefault(x => x.Name == "infoHost") as TextBlock, SocketModel.Address, 0);


        }

        //------------invoking to log console and tcp terminal
        private void SetText(ListBox console, string text)
        {
            if (!console.Dispatcher.CheckAccess())
            {
                console.Dispatcher.Invoke(new SetTerminalText(SetText),new object[]{console, text });
            }
            else
            {
                console.Items.Add(text);
            }
        }

        private void SetInfoText(TextBlock txtBlock, string text, int color)
        {
            if (!txtBlock.Dispatcher.CheckAccess())
            {
                txtBlock.Dispatcher.Invoke(new SetInfoTextBlockValue(SetInfoText), new object[] { txtBlock, text, color });
            }
            else
            {
                SolidColorBrush brush = Brushes.White;

                switch (color)
                {
                    case 0:
                        brush = Brushes.Red;
                        break;
                    case 1:
                        brush = Brushes.Green;
                        break;
                    case 2:
                        brush = Brushes.White;
                        break;
                }
                txtBlock.Foreground = brush;
                txtBlock.Text = text;
            }
        }

    //---------------tcp implementation
        private void SendMessage(object sender, RoutedEventArgs e)
        {
            string msg = inputTextBox.Text;
            _service.SendData(msg);
            SetInfoText(infoResponseTime, SocketModel.ResponseTimeout.ToString(), 1);
        }

        private void DisconnectConnection(object sender, RoutedEventArgs e)
        {
            if (SocketModel.IsConnected)
            {
                if (readingThread.IsBusy)
                    readingThread.CancelAsync();
                _service.StopConnection();
                SocketModel.Status = "Disconnected";
            }
            SetInfoText(infoStatus, SocketModel.Status, 0);

            SetText(consoleInfo,SocketModel.InfoMsg);
            buttonConnect.IsEnabled = true;
            buttonDisConnect.IsEnabled = false;
            buttonSend.IsEnabled = false;
        }

        private void TcpClientConnected(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHost.Text))
                SetText(consoleInfo,"Invalid IP Address");
            if (string.IsNullOrEmpty(txtPort.Text))
                SetText(consoleInfo,"Invalid port");

            address_to_connect = txtHost.Text;
            port_to_connect = Convert.ToInt32(txtPort.Text);

            if (!SocketModel.IsConnected)
            {
                buttonConnect.IsEnabled = false;
                buttonDisConnect.IsEnabled = true;
                SocketModel.Status = "Connected";
                SocketModel.Address = txtHost.Text;
                SocketModel.Port = port_to_connect;
                SetInfoText(infoHost, SocketModel.Address, 2);
                SetInfoText(infoPort, SocketModel.Port.ToString(), 2);
                SetInfoText(infoStatus, SocketModel.Status, 1);
                connectionThread.RunWorkerAsync();  //start connecting
            }
            else SocketModel.IsConnected = true;

            if(SocketModel.IsConnected)
            {
                connectionThread.CancelAsync();
            }
            buttonSend.IsEnabled = true;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxButton buttonClose = MessageBoxButton.YesNo;
            // MessageBoxButton buttonCancel = MessageBoxButton.
            var res = MessageBox.Show("Close app?", "Close", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
                this.Close();
           
        }


        public void GetElements(DependencyObject currentObj, int depth)
        {
            if (currentObj == null)
                throw new Exception("Not found");

            for(int i=0; i< VisualTreeHelper.GetChildrenCount(currentObj); ++i)
            {
                Console.WriteLine(new string(' ', depth)+ currentObj);
                object_list.Add(currentObj as FrameworkElement);
                GetElements(VisualTreeHelper.GetChild(currentObj, i), depth+1);
                
            }

        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            GetElements(this, 0);
            
        }
        //--------data received-----------
        public void Received_Done()
        {
            
            SetInfoText(infoReceive, SocketModel.ReceiveTimeout.ToString(), 0);

        }

    }
}
