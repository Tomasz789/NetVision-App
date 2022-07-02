using NetVision.Infrastructure.Services;
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
    /// Logika interakcji dla klasy BiosInfoPage.xaml
    /// </summary>
    public partial class BiosInfoPage : Page
    {
        private IBiosInformationService _service;
        public BiosInfoPage()
        {
            InitializeComponent();
            FillConsole();
        }

        private void FillConsole()
        {
            _service = new BiosInformationService();
            infoBox.ItemsSource = _service.GetBiosInformation();
        }
    }
}
