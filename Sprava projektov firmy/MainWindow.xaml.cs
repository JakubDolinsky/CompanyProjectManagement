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

namespace Sprava_projektov_firmy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LoggerManager LoggerManager { get; set; }
        public Logger Logger { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LoggerManager = new LoggerManager();
            try
            {
                Logger = LoggerManager.LoadLogger();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //The click method opening the main window with listbox of projects and menu buttons.
        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            if (userName.Text == Logger.Name && password.Password == Logger.Password)
            {
                MenuWindow menuWindow = new MenuWindow(LoggerManager, Logger);
                menuWindow.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Nesprávne meno alebo heslo!", "Neúspešné prihlásenie", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
