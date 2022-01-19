using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq3.Models
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Headquarters { get; set; }
        public int Year { get; set; }

        public static Manufacturer ConvertToManufacturer(string line)
        {
            var fields = line.Split(',');
            return new Manufacturer
            {
                Name = fields[0],
                Headquarters = fields[1],
                Year = int.Parse(fields[2]),
            };
        }

        
    }
}
