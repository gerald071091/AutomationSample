using AutoCore;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace PortableTestRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBaseOperation _operation;
        private static Process _process;

        public MainWindow()
        {
            InitializeComponent();
            MapperInitialization.Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _operation = PageInitialization.InitializeOperation("chrome");

            _operation.BrowseThisWebSite(ConfigurationManager.AppSettings["website"]);

            _operation.GoToDefaultTab();

            //LOL
            for (int i = 0; i < Int32.Parse(TextBoxClickCount.Text); i++)
            {
                _operation.ClickTheButton();
            }

            _operation.Quit();

            _process.EndSession("drivers".GetValue());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                TextBox.Text = filename;

                var details = ExcelHelper.UseTheProvidedData(filename, TextBoxSheetName.Text);

                foreach (var account in details)
                {
                    TextBoxDetails.Text += string.Format("User: {0}, Pass: {1}", account.Username, account.Password + Environment.NewLine);
                }
                
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextBox.Text = string.Empty;
            TextBoxDetails.Text = string.Empty;
            TextBoxSheetName.Text = string.Empty;
        }

        private void TextBoxClickCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Int32.TryParse(TextBoxClickCount.Text, out int parsedValue))
            {
                MessageBox.Show("Please provide a valid click count value.");
                ButtonAutomation.IsEnabled = false;
                return;
            }

            ButtonAutomation.IsEnabled = true;
            return;
        }
    }
}
