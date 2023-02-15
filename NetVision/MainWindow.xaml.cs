
using NetVision.ApplicationPages;
using NetVision.ApplicationPages.Home;
using NetVision.Infrastructure.Services.ProcessService.Types;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> _navigateButtons;
        public MainWindow()
        {
            InitializeComponent();
            _navigateButtons = new List<Button>();
            _navigateButtons.Add(buttonMainPage);
            _navigateButtons.Add(buttonMonitor);
            _navigateButtons.Add(buttonBiosInfo);
            _navigateButtons.Add(buttonInfos);
            _navigateButtons.Add(buttonHelp);
            _navigateButtons.Add(buttonDiagnostics);
            _navigateButtons.Add(buttonMonitor);
            _navigateButtons.Add(buttonMainPage);

           
            foreach (var item in _navigateButtons)
                item.Click += new RoutedEventHandler(PageSelected);
        }

        private IEnumerable<T> FindButtons<T>(DependencyObject obj) where T : DependencyObject
        {
            //List<Button> _buttonList = new List<Button>();
            //var button = LogicalTreeHelper.GetParent(obj);
            foreach(DependencyObject element in LogicalTreeHelper.GetChildren(obj))
            {
                if (element is DependencyObject)
                {
                    DependencyObject dependencyObject = element as DependencyObject;
                    if (element is T)
                        yield return element as T;
                    foreach (var child in FindButtons<T>(element))
                        yield return child as T;
                }
            }
          
        }
        private void PageSelected(object sender, RoutedEventArgs e)
        {
            FrameworkElement selected_button = e.Source as Button;
            Page element = new Page();

            switch (selected_button.Name)
            {
                case "buttonBiosInfo":
                    element = new BiosInfoPage();
                    break;
                case "buttonDiagnostics":
                    element = new DiagnosticsPage();
                    break;
                case "buttonInfos":
                    element = new NetStatPage();
                    break;
                case "buttonMonitor":
                    element = new ResourcesUsagePage();
                    break;
                case "buttonMainPage":
                    element = new HomePage();
                    break;
            }
            SelectPage(element);
            e.Handled = true;
        }

        private void SelectPage(Page element)
        {
            this.PagePanel.Content = element;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           /* foreach (var item in FindButtons<Button>(this))
                item.Click += new RoutedEventHandler(PageSelected);*/
        }
    }
}
