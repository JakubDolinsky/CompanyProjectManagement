using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprava_projektov_firmy
{
    public class Projekt
    {
        public int Id { get; set; } = 1;
        public string PublishedId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Customer { get; set; }

        public Projekt(string name, string abbreviation, string customer)
        {
                Name = name;
                Abbreviation = abbreviation;
                Customer = customer;   
        }
        //An empty constructor for serialisation
        public Projekt()
        { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  ");
            sb.Append(PublishedId);
            sb.Append("              ");
            sb.Append(Name);
            sb.Append("                                    ");
            sb.Append(Abbreviation);
            sb.Append("                    ");
            sb.Append(Customer);
            return sb.ToString();
        }
    }
}
