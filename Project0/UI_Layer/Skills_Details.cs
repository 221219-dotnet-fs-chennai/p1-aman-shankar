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
                Console.WriteLine("No Skill Found");
            }
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Edit Your Skill Details:- \n");

            Console.WriteLine("[1] Skill_Name : " + skill_Details.skill_name );
            Console.WriteLine("[2] Save ");
            Console.WriteLine("[4] Delete ");
            Console.WriteLine("[0] Back \n");
        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Please Enter Your Skill-Name : ");
                    skill_Details.skill_name = Console.ReadLine();
                    return "Skills_Details";
                case "2":
                    skill_Details.skill_id = LogIn.newUser.user_id;
                    newSqlRepo.AddSkills(skill_Details);
                    Console.WriteLine("Saved Skill_Details ");
                    return "AddAndEditUserDetails";
                case "3":
                    Console.WriteLine("");
                    return "Skills_Details";
                case "4":
                    Console.WriteLine("");
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
