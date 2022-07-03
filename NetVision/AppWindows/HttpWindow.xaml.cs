using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
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
using System.Windows.Shapes;

namespace NetVision.AppWindows
{
    /// <summary>
    /// Logika interakcji dla klasy HttpWindow.xaml
    /// </summary>
    public partial class HttpWindow : Window
    {
        private readonly HttpViewModel _vm;
        private SaveFileWindow fWin;
        public HttpWindow()
        {
            InitializeComponent();
            FillComponents();
            txtAddr.Text = "https://jsonplaceholder.typicode.com/todos/1";
            _vm = new HttpViewModel();
            DataContext = _vm;
            btnSave.Click += SaveValueToTxtFile;
            buttonSend.Click += RefreshWindow;
        }

        private void RefreshWindow(object sender, RoutedEventArgs e)
        {
            resultPanel.AppendText(_vm.TextValue);
        }

        private void SaveValueToTxtFile(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_vm.TextValue))
            {
                MessageBox.Show("Nothing to save.");
                return;
            }

            fWin = new SaveFileWindow(_vm.TextValue);
            fWin.Show();
        }

        private void FillComponents()
        {
            verbType.Items.Add("GET");
            verbType.Items.Add("POST");
            verbType.Items.Add("PUT");
            verbType.Items.Add("DELETE");
            verbType.SelectedIndex = 1;
        }


    }
}
