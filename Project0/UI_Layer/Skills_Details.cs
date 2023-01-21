using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Layer
{
    internal class Skills_Details :  IMenu
    {
        private static Skills skill_Details = new Skills();
        private static string cs = $"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;";
        private static SQLRepo newSqlRepo = new SQLRepo(cs);

        public void Display()
        {
            Console.WriteLine("Skill_Id : " + LogIn.newUser.user_id);
            List<Skills> list = newSqlRepo.GetSkills(LogIn.newUser.user_id);
            if (list.Count != 0)
            {
                foreach (Skills skill in list)
                {
                    Console.WriteLine("Skill Name : " + skill.skill_name);
                }
            }
            else
            {
                Console.WriteLine("No Skill Found. Please Add Your Skills");
            }
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Add , Edit ANd Update Your Skill Details:- \n");

            Console.WriteLine("[1] Skill_Id : " + skill_Details.skill_id);
            Console.WriteLine("[2] Skill_Name : " + skill_Details.skill_name );
            Console.WriteLine("[3] Save ");
            Console.WriteLine("[4] Update ");
            Console.WriteLine("[5] Delete ");
            Console.WriteLine("[0] Back \n");
        }

        public string UserOption()
        {
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
                    Console.WriteLine("Please Enter Your Skill-Id : ");
                    skill_Details.skill_id= id;
                    return "Skills_Details";
                case "2":
                    Console.WriteLine("Please Enter Your Skill-Name : ");
                    skill_Details.skill_name = Console.ReadLine();
                    return "Skills_Details";
                case "3":
                    newSqlRepo.AddSkills(skill_Details);
                    Console.WriteLine("Saved Skill_Details ! Press Enter ");
                    Console.ReadKey();
                    return "AddAndEditUserDetails";
                case "4":
                    Console.WriteLine("Please Enter Which Skill You Want To Update ! ");
                    string up_skill = Console.ReadLine();
                    /*for (int i = 0; i < skill_Details.skill_name.Length; i++)
                    {

                    }
                    if (skill_Details.skill_name ==)
                    {

                    }
                    newSqlRepo.UpdateSkills(up_skill , skill_Details.skill_name);*/
                    return "AddAndEditUserDetails";
                case "5":
                    Console.WriteLine("Please Enter Which Skill You Want To Delete ");
                    string del = Console.ReadLine();
                    for(int i = 0; i < skill_Details.skill_name.Length; i++)
                    {
                        if(skill_Details.skill_name == del)
                        {
                            Console.WriteLine(del);
                            Console.WriteLine("Press Enter For Confirmation ");
                            Console.ReadLine();
                            newSqlRepo.DeleteSkills(del);
                            Console.WriteLine("Table Is Deleted !");
                        }
                        else
                        {
                            Console.WriteLine("You Don't Have This Skill Yet ! Press Enter ");
                            Console.ReadLine();
                            break;
                        }
                    }
                    return "Skills_Details";
                case "0":
                    return "AddAndEditUserDetails";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "Skills_Details";
            }
        }
    }
}
