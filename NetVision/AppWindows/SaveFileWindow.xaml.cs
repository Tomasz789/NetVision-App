using Microsoft.Win32;
using NetVision.Infrastructure.Files;
using NetVision.Infrastructure.Files.FileTypes;
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
    /// Logika interakcji dla klasy SaveFileWindow.xaml
    /// </summary>
    public partial class SaveFileWindow : Window
    {
        private string filePath, fileName,text;
        private List<string> dataForXml = new List<string>();
        IFileService fileService;
        public SaveFileWindow(string txt)
        {
            InitializeComponent();
            buttonSave.Click += new RoutedEventHandler(SaveButtonClicked);
            
            buttonCancel.Click += new RoutedEventHandler(CancelButtonClicked);
            buttonBrowse.Click += new RoutedEventHandler(BrowseFiles);
            text = txt;
            //dataForXml = attr;
        }

        private void SaveXmlFileEvent()
        {
            fileService = new FileService();
            fileService.SaveXmlFileAsync(filePath, dataForXml);
        }

        private void SaveTxtFileEvent()
        {
            fileService = new FileService();
            var res = fileService.SaveTxtFileAsync(filePath, text);
            if (res.IsCompleted)
                MessageBox.Show("File saved successfully!");
        }
        private void BrowseFiles(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();
            sDialog.Filter = "xml files (*.xml)|*xml|All files (*.*)|*.*";// "txt files (*.txt)|*.txt|All files (*.*)|*.*" 
            sDialog.InitialDirectory = @"C:\";
            sDialog.DefaultExt = "txt";
            sDialog.CheckPathExists = true;
            if (txtFileName.Text != null && string.IsNullOrWhiteSpace(txtFileName.Text)==false)
                sDialog.FileName = txtFileName.Text;
            else throw new Exception("Invalid file name!");
            sDialog.Title = "Save As...";
            var dialogRes = sDialog.ShowDialog();
            if (dialogRes == true) {
                fileName = sDialog.FileName;
                filePath =  fileName;
                txtFilePath.Text = filePath;
             }
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            fileService = new FileService();
            if (xmlRadioButton.IsChecked == true)
                SaveXmlFileEvent();
            else
            {
                //text = "asfdsadsdf";
                var res = fileService.SaveTxtFileAsync(filePath, text);
                if (res.IsCompletedSuccessfully == true)
                    MessageBox.Show("File saved successfully!");
                Close();
            }
        }
    }
}
