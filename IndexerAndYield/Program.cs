using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerAndYield
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>()
            {
                new Car(){Name="Ford",Number="A001AA01"},
                new Car(){Name="Lada",Number="C115CD01"},
                new Car(){Name="Tesla",Number="X0888XX01"},
                new Car(){Name="BMW",Number="E001KX01"}
            };
            var parking = new Parking();
            foreach (var item in cars)
            {
                parking.Add(item);
            }

            Console.WriteLine(parking["A001AA01"]?.Name);
            Console.WriteLine(parking["A001AA77"]?.Name);
            Console.WriteLine(parking["C115CD01"]?.Name);

            //перебор Энумератором
            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
           
            foreach (var item in parking.GetNames())
            {
                Console.WriteLine($"Name: {item}");
            }

            Console.ReadKey();

        }
    }
}
