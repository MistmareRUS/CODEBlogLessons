using CodBlogFitness.BL.Controller;
using CodBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет!");
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол:");
                var gender = Console.ReadLine();
                DateTime birth = ParseDate();  
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender,birth,weight,height);

            }


            Console.WriteLine("Привет, "+ userController.CurrentUser);
            Console.ReadKey();
        }
        private static DateTime ParseDate()
        {
            DateTime date;
            do
            {
                Console.WriteLine("Введите дату рождения в формате dd.mm.yyyy");
                DateTime.TryParse(Console.ReadLine(), out  date);
            }
            while (date == DateTime.MinValue);
            return date;
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
    }
}
