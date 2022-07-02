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

namespace NetVision
{
    /// <summary>
    /// Logika interakcji dla klasy ProcessPage.xaml
    /// </summary>
    public partial class ProcessPage : Page
    {
        private readonly ProcessInfoViewModel vm;
        public ProcessPage()
        {
            InitializeComponent();
            vm = new ProcessInfoViewModel();
            DataContext = vm;
        }
    }
}
