using NetVision.ApplicationPages.HardwarePages.Plot;
using NetVision.ApplicationPages.Panels;
using NetVision.DataCore.PerformanceValueTypes;
using NetVision.PagesInfo;
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

namespace NetVision.ApplicationPages.HardwarePages
{
    /// <summary>
    /// Logika interakcji dla klasy VisualizationPage.xaml
    /// </summary>
    public partial class VisualizationPage : Page
    {
        private PageSignal<Page> _currentPage;
        private PerformanceValueType valType;
        public VisualizationPage(string type)
        {
            InitializeComponent();
            //_currentPage = new PageSignal<DataShowPage>();

            SetValueType(type);
        }

        private void SetValueType(string type)
        {
            switch (type)
            {
                case "CPU":
                    valType = PerformanceValueType.CPU;
                    break;
                case "RAMTOTAL":
                    valType = PerformanceValueType.RAM_TOTAL;
                    break;
                default:
                    throw new ArgumentException("Invalid Perform. value type");
            }

            DataShowPanel dPanel = new DataShowPanel(valType);
            dataPanel.Content = dPanel;
            ChartView plot = new ChartView(valType);
            plotPanel.Content = plot;
        }
    }
}
