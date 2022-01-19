using Linq2.Models;
using Linq3.Models;
using System;

namespace Linq3
{
    class Program
    {
        static void Main()
        {
            var manufacturers = ProccessFile("Documents/manufacturers.csv");
            var processedCars = ProccessCarsFile("Documents/vehicles.csv");
            var cars = processedCars
                .Join(manufacturers,
                    c=>c.Manufacturer, // outer key selector
                    m=>m.Name,
                    (c, m) => new
                    {
                        m.Headquarters,
                        c.Name,
                        c.Combined,
                        c.Manufacturer
                    }
                )
                .Where(c=>c.Manufacturer == "BMW")
                .OrderByDescending(car => car.Combined)
                .ThenBy(car => car.Name)
                .Take(10);
            /*var cars = from car in processedCars
                       join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
                       orderby car.Combined descending, car.Name ascending
                       select new 
                       {
                            manufacturer.Headquarters,
                            car.Name,
                            car.Combined
                       };*/

            foreach (var car in cars.Take(15))
                Console.WriteLine($"{car.Headquarters} : {car.Name} : {car.Combined}");


            /*var processedManufacturers = ProccessFile("Documents/manufacturers.csv");

            var Manufacturers = processedManufacturers;
            foreach (var Manufacturer in Manufacturers)
                Console.WriteLine($"{Manufacturer.Name} : {Manufacturer.Headquarters} : {Manufacturer.Year}");*/
        }


        private static IEnumerable<Manufacturer> ProccessFile(string path)
        {
            // Projection using select
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Manufacturer.ConvertToManufacturer);
        }

        private static IEnumerable<Car> ProccessCarsFile(string path)
        {
            // Projection using select
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ConvertToCar);
        }


    }

}