using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using Cafe.BL;
using Cafe.BL.Controller;
using Cafe.BL.Model;

namespace Cafe.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Cafe.CMD.Languages.Message", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("hello", culture));

            Console.WriteLine(resourceManager.GetString("enterName", culture));
            var name = Console.ReadLine();

            
            var userController = new UserController(name);
            var ordercontroller = new OrderController(userController.CurrentUser);
            
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter gender");
                var gender = Console.ReadLine();

                DateTime birthDate=ParseDateTime("birdthday");
                

                Console.WriteLine("Enter Number");
                var number = Console.ReadLine();

                Console.WriteLine("Enter Addres");
                var addres = Console.ReadLine();
                userController.SetNewUserData(gender,birthDate,number,addres);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E-introduce product.");
            
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterOrder();

                ordercontroller.Add(foods.Food,4);
                foreach (var item in ordercontroller.Order.Foods)
                {
                    Console.WriteLine($"{item.Key}-{item.Value}");
                    
                }
            }

        }

        public static (Food Food,double quantity) EnterOrder()
        {
            Console.WriteLine("Enter product name.");
            var foodname = Console.ReadLine();
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrates = ParseDouble("carbohydrates");
            var calories = ParseDouble("calories");
            var price = ParseDouble("price");
            var food = new Food(foodname, proteins, fats, carbohydrates, calories, price);
            return (food,7);

        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter{value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid date format {value}");
                }
            }

            return birthDate;
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
    }
}
