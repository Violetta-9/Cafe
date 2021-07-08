using System;
using System.Runtime.InteropServices;
using Cafe.BL;
using Cafe.BL.Controller;


namespace Cafe.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the cafe app");

            Console.WriteLine("Enter username");
            var name = Console.ReadLine();

            
            var userController = new UserController(name);
            
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
    }
}
