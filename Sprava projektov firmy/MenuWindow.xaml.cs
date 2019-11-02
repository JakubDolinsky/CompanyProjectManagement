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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public ProjectManager ProjectManager { get; set; }
        public LoggerManager LoggerManager { get; set; }
        public Logger Logger { get; set; }

        public MenuWindow(LoggerManager loggerManager, Logger logger)
        {
            InitializeComponent();
            LoggerManager = loggerManager;
            ProjectManager = new ProjectManager(logger, loggerManager);
            Logger = logger;
            DataContext = ProjectManager;
            try
            {
                ProjectManager.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //The click method opening a window for setting new user name and password.
        private void ChangeLogin_Click(object sender, RoutedEventArgs e)
        {
            ChangeLoginWindow changeLoginWindow = new ChangeLoginWindow(LoggerManager);
            changeLoginWindow.ShowDialog();
        }

        //The click method deleting selected project from the list.
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Naozaj chcete odstrániť zvolený projekt?", "Vymazanie projektu", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    try
                    {
                        ProjectManager.DeleteProject((Projekt)projListBox.SelectedItem);
                        ProjectManager.Save();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        //The click method opening a window for editing a new project.
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditWindow editWindow = new EditWindow(ProjectManager, (Projekt)projListBox.SelectedItem);
                editWindow.ShowDialog();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //The click method opening a window for adding a new project.
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(ProjectManager);
            addWindow.ShowDialog();
        }

        //The click method for clear collection of projects and set default user name and password. 
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Naozaj chcete vyčistiť zoznam projektov a resetovať prihlasovacie údaje?", "Reset", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    try
                    {
                        ProjectManager.ListOfProjects.Clear();
                        ProjectManager.Save();
                        Logger.Name = "user";
                        Logger.Password = "user";
                        LoggerManager.SaveLogger();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
    }
}
