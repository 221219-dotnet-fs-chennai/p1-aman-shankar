using DataLayer;
using System.Collections.Generic;

namespace UI_Layer
{
    internal class Personal_Details : IMenu  
    {
        //private static string cs = File.ReadAllText("D:/Revature/Project1/UI_Layer/ConnectionString.txt");
        private static string cs = "Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static User user = new User();
        private static SQLRepo sRepo = new SQLRepo(cs);

         
        

        public void Display()
        {
            Console.WriteLine("User-Id : " + LogIn.newUser.user_id);
            Console.WriteLine("Email : " + LogIn.newUser.Email);
            Console.WriteLine("Password : " + LogIn.newUser.password);
            List<User> list = sRepo.GetUser(LogIn.newUser.user_id);
            foreach (User user in list)
            {
                Console.WriteLine("First-Name : " + user.first_name);
                Console.WriteLine("Middle-Name : " + user.middle_name);
                Console.WriteLine("Last-Name : " + user.last_name);
                Console.WriteLine("Gender : " + user.gender);
                Console.WriteLine("Pincode : " + user.pincode);
                Console.WriteLine("Website : " + user.website);
                Console.WriteLine("Mobile_Number : " + user.mobile_number);
                Console.WriteLine("About_Me : " + user.about_me);
            }
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Edit Your Personal Details:- \n");
            


            Console.WriteLine("[1] First-Name : " + user.first_name);   
            Console.WriteLine("[2] Middle-Name : " + user.middle_name);
            Console.WriteLine("[3] Last-Name : " + user.last_name);
            Console.WriteLine("[4] Gender : " + user.gender);
            Console.WriteLine("[5] Pincode : " + user.pincode);
            Console.WriteLine("[6] Website : " + user.website);
            Console.WriteLine("[7] Mobile_Number : " + user.mobile_number);
            Console.WriteLine("[8] About_Me : " + user.about_me);
            Console.WriteLine("[9] Delete ");
            Console.WriteLine("[10] Save Details ");
            Console.WriteLine("[0] Back");


        }

        public string UserOption()
        {
            string userInput = Console.ReadLine();
            Validation newValidation = new(cs);
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Your First-name : ");
                    user.first_name = Console.ReadLine();
                    return "Personal_Details";
                case "2":
                    Console.WriteLine("Enter Your Middle-Name : ");
                    user.middle_name = Console.ReadLine();
                    return "Personal_Details";
                case "3":
                    Console.WriteLine("Enter Your Last-Name : ");
                    user.last_name = Console.ReadLine();
                    return "Personal_Details";
                case "4":
                    Console.WriteLine("Enter Your Gender : ");
                    user.gender = Console.ReadLine();
                    return "Personal_Details";
                case "5":
                    Console.WriteLine("Enter Your Pincode : ");
                    user.pincode = Console.ReadLine();
                    if (newValidation.IsValidPincode(user.pincode))
                    {
                        return "Personal_Details";
                    }
                    else
                    {
                        Console.WriteLine("Please Enter A 6 Digit Valid Pincode. Press Enter To Retry !");
                        Console.ReadLine();
                        return "Personal_Details";
                    }
                case "6":
                    Console.WriteLine("Enter Your Website : ");
                    user.website = Console.ReadLine();
                    return "Personal_Details";
                case "7":
                    Console.WriteLine("Enter Your Mobile-Number : ");
                    user.mobile_number = Console.ReadLine();

                    if (newValidation.IsValidNumber(user.mobile_number))
                    {
                        return "Personal_Details";
                    }
                    else
                    {
                        Console.WriteLine("Mobile Number Is Not Valid. Please Press Enter To Write Mobile Number Again ! ");
                        Console.ReadLine();
                    }
                    return "Personal_Details";
                case "8":
                    Console.WriteLine("Enter Your About_Me : ");
                    user.about_me = Console.ReadLine();
                    return "Personal_Details";
                case "10":
                    sRepo.AddUser(user);
                    Console.WriteLine("User Deatils Added ! ");
                    return "AddAndEditUserDetails";
                case "9":
                    sRepo.Delete(user);
                    Console.WriteLine("Table is deleted");
                    return "Personal_Details";
                case "0":
                    return "AddAndEditUserDetails";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "Personal_Details";
            }
        }
    }
}
