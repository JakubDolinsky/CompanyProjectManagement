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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public ProjectManager ProjectManager {get;set;}
        public AddWindow(ProjectManager projectManager )
        {
            InitializeComponent();
            ProjectManager = projectManager;
        }

        //The click method confirming and saving newly added project. 
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjectManager.AddProject(projName.Text, abbrev.Text, customer.Text);
                ProjectManager.Save();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
