using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 15;
            Console.WriteLine(x.IsEven());
            Console.WriteLine(x.IsDevidedBy(3));

            var list = new List<Road>
            {
                new Road("M4",2000),
                new Road("M1",900),
                new Road("E95", 1200)
            };
            Console.WriteLine(list.ConvertToString());

            Console.ReadKey();
        }
    }
}
