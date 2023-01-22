using DataLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Layer
{
    internal class Education_Details : IMenu
    {
        private static Education ed_Details= new Education();
        private static string cs = $"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;";
        private static SQLRepo sRepo = new SQLRepo(cs);
        public void Display()
        {
            Console.WriteLine("Education_Id : " + LogIn.newUser.user_id);
            List<Education> list = sRepo.GetEducation(LogIn.newUser.user_id);
            if (list.Count != 0)
            {
                foreach (Education ed_info in list)
                {
                    Console.WriteLine("Education_Name : " + ed_info.education_name);
                    Console.WriteLine("Institute_Name : " + ed_info.institute_name);
                    Console.WriteLine("Grade : " + ed_info.grade);
                    Console.WriteLine("Duration : " + ed_info.duration);
                }
            }else
            {
                Console.WriteLine("No Education_Details Found ! ");
            }
            Console.WriteLine("----------------------------------\n");

            Console.WriteLine("Add , Edit ANd Update Your Education Details \n");
            Console.WriteLine("[1] Education_Id : " + ed_Details.education_id);
            Console.WriteLine("[2] Education_Name : " + ed_Details.education_name);
            Console.WriteLine("[3] Institute_Name : " + ed_Details.institute_name);
            Console.WriteLine("[4] Grade : " + ed_Details.grade);
            Console.WriteLine("[5] Duration : " + ed_Details.duration);
            Console.WriteLine("[6] Save :");
            Console.WriteLine("[7] Delete ");
            Console.WriteLine("[0] Back:- \n");
        }

        public string UserOption()
        {
            List<Education> list = sRepo.GetEducation(LogIn.newUser.user_id);

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
                    Console.WriteLine("Please Enter Your Education_Id");
                    ed_Details.education_id = id;
                    return "Education_Details";
                case "2":
                    Console.WriteLine("Please Enter Your Education-Name : ");
                    ed_Details.education_name = Console.ReadLine();
                    return "Education_Details";
                case "3":
                    Console.WriteLine("Please Enter Your Institute Name : ");
                    ed_Details.institute_name = Console.ReadLine();
                    return "Education_Details";
                case "4":
                    Console.WriteLine("Please Enter Your Grade : ");
                    ed_Details.grade = Console.ReadLine();
                    return "Education_Details";
                case "5":
                    Console.WriteLine("Please Enter The Duration For Taking This Degree : ");
                    ed_Details.duration = Console.ReadLine();
                    return "Education_Details";
                case "6":
                    sRepo.AddEducation(ed_Details);
                    Console.WriteLine("Saved Education_Details ! Press Enter ");
                    Console.ReadKey();
                    return "AddAndEditUserDetails";
                case "7":
                    Console.WriteLine("Please Enter Education Name You Want To Delete ");
                    string del = Console.ReadLine();
                    if (list.Count != 0)
                    {
                        foreach (Education ed_info in list)
                        {
                            if (ed_info.education_name == del)
                            {
                                sRepo.DeleteEducation(ed_info.education_name, id);
                                Console.WriteLine("Selected Education Record Is Deleted ! Press Enter To See Changes. ");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                    return "Education_Details";
                case "0":
                    return "AddAndEditUserDetails";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "Education_Details";
            }
        }
    }
}
