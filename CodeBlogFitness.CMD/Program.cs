using CodBlogFitness.BL.Controller;
using CodBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CurrentCulture;
            //var culture = CultureInfo.CreateSpecificCulture("en-US");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello",culture));
            Console.WriteLine(resourceManager.GetString("EnterName",culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender",culture));
                var gender = Console.ReadLine();
                DateTime birth = ParseDate();  
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender,birth,weight,height);

            }
            Console.WriteLine("Привет, "+ userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е- ввести прием пищи.");
            var key=Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods=EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key}-{item.Value}" );
                }
            }


            Console.ReadKey();
        }

        private static (Food Food,double Weight) EnterEating()
        {
            Console.WriteLine("Введите название продукта.");
            var food = Console.ReadLine();
            var cal = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, cal, prots, fats, carbs);

            return  (Food:product,Weight: weight);
;        }

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
