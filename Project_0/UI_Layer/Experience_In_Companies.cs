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
        private static string cs = $"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;";
        private static SQLRepo sRepo = new SQLRepo(cs);
        public static Company newUs = new Company();
        public void Display()
        {
            Console.WriteLine("Company_Id : " + LogIn.newUser.user_id);
            List<Company> list = sRepo.GetCompany(LogIn.newUser.user_id);
            if (list.Count != 0)
            {
                foreach (Company com in list)
                {
                    Console.WriteLine("Company_Name : " + com.company_name);
                    Console.WriteLine("Industry : " + com.industry);
                    Console.WriteLine("Duration : " + com.duration);
                }
            }
            else
            {
                Console.WriteLine("No Company_Details Found.Please Add Company !");
            }
            Console.WriteLine("----------------------------------\n");

            Console.WriteLine("Add , Edit ANd Update Your Experience_In_Companies Details:- \n");
            Console.WriteLine("[1] Company_Id : " + newUs.company_id);
            Console.WriteLine("[2] Company_name : " + newUs.company_name );
            Console.WriteLine("[3] Industry : " + newUs.industry );
            Console.WriteLine("[4] Duration : " + newUs.duration );
            Console.WriteLine("[5] Save ");
            Console.WriteLine("[6] Update ");
            Console.WriteLine("[7] Delete ");
            Console.WriteLine("[0] Back \n");
        }

        public string UserOption()
        {
            List<Company> list = sRepo.GetCompany(LogIn.newUser.user_id);
            string id;
            if (LogIn.newUser.user_id != null && SignUp.newuser.user_id == null)
            {
                id = LogIn.newUser.user_id;
            }
            else
            {
                id = SignUp.newuser.user_id;
            }
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please Enter Your Company_Id");
                    newUs.company_id = id;
                    return "Experience_In_Companies";
                case "2":
                    Console.WriteLine("Please Enter Your Company-Name : ");
                    newUs.company_name = Console.ReadLine();
                    return "Experience_In_Companies";
                case "3":
                    Console.WriteLine("Please Enter Your Industry Name : ");
                    newUs.industry = Console.ReadLine();
                    return "Experience_In_Companies";
                case "4":
                    Console.WriteLine("Please Enter The Duration For Taking This Degree : ");
                    newUs.duration = Console.ReadLine();
                    return "Experience_In_Companies";
                case "5":
                    sRepo.AddCompany(newUs);
                    Console.WriteLine("Saved Company_Details ! Press Enter ");
                    Console.ReadKey();
                    return "Experience_In_Companies";
                case "6":
                    Console.WriteLine("Please Enter Comapany Name You Want To Update ");
                    string upd = Console.ReadLine();
                    if (list.Count != 0)
                    {
                        foreach (Company comp_info in list)
                        {
                            if (comp_info.company_name == upd)
                            {
                                sRepo.UpdateCompany(comp_info, upd, id);
                            }
                        }
                    }
                    return "Experience_In_Companies";
                case "7":
                    Console.WriteLine("Please Enter Company Name You Want To Delete ");
                    string del = Console.ReadLine();
                    if (list.Count != 0)
                    {
                        foreach (Company comp in list)
                        {
                            if (comp.company_name == del)
                            {
                                sRepo.DeleteCompany(comp.company_name, id);
                                Console.WriteLine("Selected Company Record Is Deleted ! Press Enter To See Changes. ");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                    return "Experience_In_Companies";
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
