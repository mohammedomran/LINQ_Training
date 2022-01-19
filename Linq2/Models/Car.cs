using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }

        public static Car ConvertToCar(string line)
        {
            var fields = line.Split(',');
            return new Car
            {
                Year = int.Parse(fields[0]),
                Manufacturer = fields[1],
                Name = fields[2],
                Displacement = double.Parse(fields[3]),
                Cylinders = int.Parse(fields[4]),
                City = int.Parse(fields[5]),
                Highway = int.Parse(fields[6]),
                Combined = int.Parse(fields[7])
            };
        }

        
    }
}
