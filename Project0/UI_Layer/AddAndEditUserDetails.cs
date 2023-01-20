using System;
using DataLayer;

namespace UI_Layer
{
    internal class AddAndEditUserDetails : IMenu
    {
        /*
        private static User newUser = new User();
        private static string cs = File.ReadAllText("D:/Revature/Project1/UI_Layer/ConnectionString.txt");
        ISqlRepo newSqlRepo = new SqlRepo(cs);
        */
        bool repeat = true;
        IMenu menu = new Menu();
        public void Display()
        {
            Console.WriteLine("Please Select Any One Option For Next Step : \n\n");
            Console.WriteLine("[1] Personal_Details : ");
            Console.WriteLine("[2] Education_Details : ");
            Console.WriteLine("[3] Skills_Details : ");
            Console.WriteLine("[4] Experience_In_Companies : ");
            Console.WriteLine("[0] Logout : \n");
        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "Personal_Details";
                case "2":
                    return "Education_Details";
                case "3":
                    return "Skills_Details";
                case "4":
                    return "Experience_In_Companies";
                case "0":
                    return "Menu";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "AddAndEditUserDetails";
            }
        }

    }
}
