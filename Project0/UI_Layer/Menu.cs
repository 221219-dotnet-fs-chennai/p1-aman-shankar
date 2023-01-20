using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Layer
{
    internal class Menu : IMenu
    {
        public static User newus = new User();
        public void Display()
        {
            Console.WriteLine("----------Welcome to the Trainer's Page----------\n\n");
            Console.WriteLine("Select An Option From The Given Below : \n");
            Console.WriteLine("[1] Menu ");
            Console.WriteLine("[2] Sign Up ");
            Console.WriteLine("[3] Log In ");
            Console.WriteLine("[0] Exit \n");
        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    return "Menu";
                case"2":
                    return "SignUp";
                case"3":
                    return "LogIn";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "Menu";
            }



























        }
    }
}
