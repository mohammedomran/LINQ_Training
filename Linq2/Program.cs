using Linq2.Models;
using System.Linq;

namespace Linq2
{
    class Program
    {
        static void Main()
        {
            // use ThenBy to perform multi ordering
            // any(O(n) always) vs contains(O(n) for lists or O(1) for hash tables)
            // ordering is very important : feltering before ordering make query more fast
            // we can use anonymous type objects when select "to return specific fields" instead of creating a new class
            // or we can user .Select(x=>new {x.Name, x.Manufacturer, .....})
            // SelectMany : flattening data means to get SubCollection of Collection like like Car[i]=>List<Passenger>

            var processedCars = ProccessFile("Documents/vehicles.csv");

            var cars = processedCars
                .Where(x => x.Manufacturer == "BMW")
                .OrderByDescending(car => car.Combined)
                .ThenBy(car => car.Name)
                .Take(10);
            foreach (var car in cars)
                Console.WriteLine($"{car.Manufacturer} : {car.Name} : {car.Combined}");
        }


        private static IEnumerable<Car> ProccessFile(string path)
        {
            // Projection using select
            /*return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ConvertToCar);*/

            // Projection using an extension methods
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .ToCar();
        }
        

    }

    // extension method to perform projecting on file lines and convert them into IEnumerable<Car>
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> lines)
        {

            foreach (var line in lines)
            {
                var fields = line.Split(',');
                yield return new Car
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
}