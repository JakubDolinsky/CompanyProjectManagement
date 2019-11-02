using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Sprava_projektov_firmy
{
    //The class of the object managing projects.
    public class ProjectManager: LoggerManager 
    {
        private static int generatedId;
        public string ViaComplete { get; set; } 
        public Projekt Projekt { get; set; }
        public LoggerManager LoggerManager { get; set; }
        public ObservableCollection<Projekt> ListOfProjects { get; set; }

        public ProjectManager(Logger logger, LoggerManager loggerManager)
        {
            ListOfProjects = new ObservableCollection<Projekt>();
            Logger = logger;
            LoggerManager = loggerManager;
            ViaComplete = Path.Combine(LoggerManager.Via, logger.path1);
        }

        //Saving method. If the app diectory exists a xml file with project collection is saved there. 
        public void Save()
        {
            if (SetDirectory() == false)
            {
                throw new Exception(error);
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(ListOfProjects.GetType());
                using (StreamWriter sw = new StreamWriter(ViaComplete))
                {                   
                    serializer.Serialize(sw, ListOfProjects);
                }
            }
        }

        //The method for loading collection of projects from xml file. If the xml file does not exist, a new empty collection
        //is created.
        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(ListOfProjects.GetType());
            if (File.Exists(ViaComplete))
            {
                using (StreamReader sr = new StreamReader(ViaComplete))
                {
                    ListOfProjects = (ObservableCollection<Projekt>)serializer.Deserialize(sr);
                }
            }
            else
            {
                ListOfProjects= new ObservableCollection<Projekt>();
            }
        }

        //The method for adding a new project to the list of projects. 
        public void AddProject(string name, string abbreviation, string customer)
        {
            if (name == string.Empty)
            {
                throw new ArgumentException("Pole pre meno projektu je prázdne!");
            }
            else if (abbreviation == string.Empty)
            {
                throw new ArgumentException("Pole pre skratku je prázdne!");
            }
            else if (customer == string.Empty)
            {
                throw new ArgumentException("Pole pre názov zákazníka je prázdne!");
            }
            else
            {
                Projekt = new Projekt(name, abbreviation, customer);
                //Generating an unique ID. Then method is checking project ID if it does not repeat, because 
                //after app restar, the static property "generatedId" starts generating ID from 1.
                generatedId++;
                Projekt.Id = generatedId;
                foreach (Projekt pr in ListOfProjects)
                {
                    while (pr.Id == Projekt.Id)
                    {
                        Projekt.Id++;
                    }
                }
                Projekt.PublishedId = "proj" + Projekt.Id.ToString();
                ListOfProjects.Add(Projekt);
            }
        }

        //The method for editing project properties
        public void EditProjekt(Projekt projekt, string name, string abbreviation, string customer)
        {
            if (name == string.Empty)
            {
                throw new ArgumentException("Pole pre meno projektu je prázdne!");
            }
            else if (abbreviation == string.Empty)
            {
                throw new ArgumentException("Pole pre skratku je prázdne!");
            }
            else if (customer == string.Empty)
            {
                throw new ArgumentException("Pole pre názov zákazníka je prázdne!");
            }
            else
            {
                int index = ListOfProjects.IndexOf(projekt);
                string transID = projekt.PublishedId;
                DeleteProject(projekt);
                AddProject(name, abbreviation, customer);
                foreach (Projekt a in ListOfProjects)
                {
                    if (a.Name == name)
                    {
                        a.PublishedId = transID;
                    }
                }
                ListOfProjects.Move((ListOfProjects.Count - 1), index);
            }

        }

        //The method for deleting a project from the list
        public void DeleteProject(Projekt projekt)
        {
            if (projekt == null)
            {
                throw new ArgumentException("Nie je zvoleny projekt!");
            }
            else if (ListOfProjects == null)
            {
                throw new ArgumentException("Zoznam projektov je prazdny!");
            }
            else
            {
                ListOfProjects.Remove(projekt);
            }
        }
    }
}
