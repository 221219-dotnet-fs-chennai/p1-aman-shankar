using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Layer
{
    internal class Experience_In_Companies : IMenu
    {
        private static string cs = "Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static SQLRepo sRepo = new SQLRepo(cs);
        public static Company newUs = new Company();
        public void Display()
        {
            Console.WriteLine("Company_Id : " + LogIn.newUser.user_id);
            List<Company> list = sRepo.GetCompany(LogIn.newUser.user_id);
            if (list.Count != 0)
            {
                foreach (Company newUs in list)
                {
                    Console.WriteLine("Company_Name : " + newUs.company_name);
                    Console.WriteLine("Industry : " + newUs.industry);
                    Console.WriteLine("Duration : " + newUs.duration);
                }
            }
            else
            {
                Console.WriteLine("No Company_Details Found !");
            }
            Console.WriteLine("----------------------\n");

            Console.WriteLine("Edit Your Experience_In_Companies Details:- \n");
            Console.WriteLine("[1] Company_name : " + newUs.company_name );
            Console.WriteLine("[2] Industry : " + newUs.industry );
            Console.WriteLine("[3] Duration : " + newUs.duration );
            Console.WriteLine("[4] Save ");
            Console.WriteLine("[0] Back \n");
        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please Enter Your Company-Name : ");
                    newUs.company_name = Console.ReadLine();
                    return "Experience_In_Companies";
                case "2":
                    Console.WriteLine("Please Enter Your Industry Name : ");
                    newUs.industry = Console.ReadLine();
                    return "Experience_In_Companies";
                case "3":
                    Console.WriteLine("Please Enter The Duration For Taking This Degree : ");
                    newUs.duration = Console.ReadLine();
                    return "Experience_In_Companies";
                case "4":
                    sRepo.AddCompany(newUs);
                    Console.WriteLine("Saved Company_Details ");
                    return "AddAndEditUserDetails";
                case "0":
                    return "AddAndEditUserDetails";
                default:
                    Console.WriteLine("Please Input A Valid response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "Experience_In_Companies";
            }
        }
    }
}
