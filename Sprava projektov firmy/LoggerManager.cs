using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sprava_projektov_firmy
{
    //The Class of the object managing the object which stores user name, password, and path of the xml file, where 
    // a collection of projects is saved. This container object is saved to the special xml file.
    public class LoggerManager
    {
        private string path2;
        public string error { get; set; }
        public string Via { get; set; }
        private string viaComp;
        public Logger Logger { get; set; }

        public LoggerManager()
        {
            path2 = "logger1.xml";
            Via = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SpravaProjektovFirmy");
            viaComp = Path.Combine(Via, path2);
        }

        //The method for setting a new directory of the app. 
        public bool SetDirectory()
        {
            bool succes;
            if (!Directory.Exists(Via))
            {
                Directory.CreateDirectory(Via);
                if (Directory.Exists(Via))
                {
                    succes = true;
                    return succes;
                }
                else
                {
                    error = $"Nepodarilo sa vytvoriť zložku {Via}, skontrolujte oprávnenia";
                    succes = false;
                    return succes;                    
                }               
            }
            else
            {
                succes = true;
                return succes;
            }
        }

        //Saving method. If the app diectory exists a xml file with project collection is saved there. 
        public void SaveLogger()
        {
            if (SetDirectory() == false)
            {
                throw new Exception(error);
            }
            else
            {                
                using (StreamWriter sw = new StreamWriter(viaComp))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Logger));
                    serializer.Serialize(sw, Logger);
                }
            }
        }

        //The method for loading the object where are stored loging information and path of the xml file with collection of projects
        //from xml file. If the xml file does not exist, a new object is created.
        public Logger LoadLogger()
        {            
            if (File.Exists(viaComp))
            {
                using (StreamReader sr = new StreamReader(viaComp))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Logger));
                    Logger = (Logger)serializer.Deserialize(sr);
                    return Logger;
                }
            }
            else
            {
                Logger = new Logger("user", "user");
                return Logger;
            }
        }

        //The method for editing user name and password.
        public void EditLogger(Logger logger, string name, string password)
        {
            if (name == string.Empty)
            {
                throw new ArgumentException("Pole pre meno je prázdne!");
            }
            else if (password == string.Empty)
            {
                throw new ArgumentException("Pole pre heslo je prázdne!");
            }
            else
            {
                logger.Name = name;
                logger.Password = password;
            }
        }
    }


}
