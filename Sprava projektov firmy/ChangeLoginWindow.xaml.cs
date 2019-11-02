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

namespace Sprava_projektov_firmy
{
    /// <summary>
    /// Interaction logic for ChangeLoginWindow.xaml
    /// </summary>
    public partial class ChangeLoginWindow : Window
    {
        public LoggerManager LoggerManager { get; set; }

        public ChangeLoginWindow(LoggerManager loggerManager)
        {
            InitializeComponent();
            LoggerManager = loggerManager; 
        }

        //The click method confirming and saving new user name and password.
        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoggerManager.EditLogger(LoggerManager.Logger, userName.Text, password.Password);
                LoggerManager.SaveLogger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
