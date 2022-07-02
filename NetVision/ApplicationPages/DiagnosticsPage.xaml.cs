using NetVision.AppWindows;
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
    /// Logika interakcji dla klasy DiagnosticsPage.xaml
    /// </summary>
    public partial class DiagnosticsPage : Page
    {
        public DiagnosticsPage()
        {
            InitializeComponent();
        }

        private void ShowPing_Click(object sender, RoutedEventArgs e)
        {
            var page = new PingPage();
            this.TerminalPanel.Content = page;
        }

        private void ShowTraceRoute_Click(object sender, RoutedEventArgs e)
        {
            var page = new TraceRoutePage();
            this.TerminalPanel.Content = page;
        }

        private void OpenTcpWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new TcpClientWindow();
            window.Show();
        }

        private void OpenHttpWindow_Click(object sender, RoutedEventArgs e)
        {
            HttpWindow httpWin = new HttpWindow();
            httpWin.Show();
        }
    }
}
