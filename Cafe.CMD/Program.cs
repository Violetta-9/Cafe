using System;
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

            Console.WriteLine("Enter gender");
            var gender = Console.ReadLine();
            
            Console.WriteLine("Enter Birdthday");
            var birdthey = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Number");
            var number = Console.ReadLine();

            Console.WriteLine("Enter Addres");
            var addres = Console.ReadLine();
            var userController = new UserController(name,gender,birdthey,number,addres);
            userController.Save();
           




        }
    }
}
