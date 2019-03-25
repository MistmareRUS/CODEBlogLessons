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
            Console.WriteLine("Введите пол пользователя:");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения");
            var birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите вес");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name,gender,birthDate,weight,height);
            userController.Save();


            Console.ReadKey();
        }
    }
}
