using NetVision.Infrastructure.Services.ProcessService;
using NetVision.Infrastructure.Services.ProcessService.Types;
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

namespace NetVision.ApplicationPages.Home
{
    /// <summary>
    /// Logika interakcji dla klasy HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly List<Button> buttonList;
        public HomePage()
        {
            InitializeComponent();
            buttonList = new List<Button>();
            buttonList.Add(cmdBtn);
            buttonList.Add(controlBtn);
            buttonList.Add(fileExplorerBtn);
            buttonList.Add(devBtn);
            buttonList.Add(taskBtn);

            foreach (var btn in buttonList)
            {
                btn.Click += new RoutedEventHandler(ButtonSelected);
            }
        }

        private void ButtonSelected(object sender, RoutedEventArgs e)
        {
            var selectedButton = e.Source as Button;
            ProcessLauncher launcher = null;

            switch (selectedButton.Name)
            {
                case "cmdBtn":
                    {
                        launcher = new ProcessLauncher(ProcessTypes.CMD);
                    }
                    break;
                case "controlBtn":
                    {
                        launcher = new ProcessLauncher(ProcessTypes.CONTROL);
                    }
                    break;
                case "fileExplorerBtn":
                    {
                        launcher = new ProcessLauncher(ProcessTypes.EXPLORER);
                    }
                    break;
                case "devBtn":
                    {
                        launcher = new ProcessLauncher(ProcessTypes.DEVMGMT);
                    }
                    break;
                case "taskBtn":
                    {
                        launcher = new ProcessLauncher(ProcessTypes.TASKMGR);
                    }
                    break;
            }

            try
            {
                launcher.LaunchProcess();
            }
            catch (System.ComponentModel.Win32Exception winEx)
            {
                MessageBox.Show(winEx.Message);
            }
        }
    }
}
