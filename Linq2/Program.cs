using Linq2.Models;

namespace Linq2
{
    class Program
    {
        static void Main()
        {
            var processedCars = ProccessFile("Documents/vehicles.csv");
            
            var cars = processedCars
                       .OrderByDescending(car => car.Combined)
                       .ThenBy(car => car.Name)
                       .Take(10);
            foreach (var car in cars)
                Console.WriteLine($"{car.Name} : {car.Combined}");
        }

        private static List<Car> ProccessFile(string path)
        {
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ConvertToCar)
                    .ToList();
        }

    }
}