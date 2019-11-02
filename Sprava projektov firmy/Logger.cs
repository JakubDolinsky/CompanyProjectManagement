using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprava_projektov_firmy
{
    //The class of the small object storing user name, password and path of xml file, where collection of projects is saved.
    public class Logger
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string path1 { get; set; }

        public Logger()
        { }

        public Logger(string name, string password)
        {
            path1 = "projects.xml";
            Name = name;
            Password = password;
        }
    }
}
