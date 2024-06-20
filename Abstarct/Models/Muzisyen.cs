using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Abstarct.Models
{
    public class Muzisyen
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Enstruman Enstruman { get; set; }
        public override string ToString()
        {
            return $"""
                Muzisyen ______________
                    Adi: {Name}
                    Soyadi: {Surname}
                Enstruman______________
                    {Enstruman.ToString()}
                    
                """;
        }
    }
}
