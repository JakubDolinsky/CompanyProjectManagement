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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ProjectManager ProjectManager { get; set; }
        public Projekt Projekt { get; set; }
        public EditWindow(ProjectManager projectManager, Projekt projekt)
        {
            InitializeComponent();
            ProjectManager = projectManager;
            if (projekt == null)
            {
                throw new ArgumentException("Nie je zvolený žiadny projekt!");
            }
            else if (ProjectManager.ListOfProjects == null)
            {
                throw new ArgumentException("Zoznam projektov je prazdny!");
            }
            else
            {
                Projekt = projekt;
            }
            DataContext = projekt;
        }

        //The click method confirming and saving new project settings.
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProjectManager.EditProjekt(Projekt, projName.Text, abbrev.Text, customer.Text);
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
