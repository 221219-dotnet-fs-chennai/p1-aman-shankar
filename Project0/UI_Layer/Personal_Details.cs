using DataLayer;
using System.Collections.Generic;

namespace UI_Layer
{
    internal class Personal_Details : IMenu  
    {
        private static string cs = $"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;";
        private static User user = new User();
        private static SQLRepo sRepo = new SQLRepo(cs);

         
        

        public void Display()
        {
            if (LogIn.newUser.user_id != null && SignUp.newuser.user_id == null)
            {
                Console.WriteLine("User-Id : " + LogIn.newUser.user_id);
            }
            else {
                Console.WriteLine("User-Id : " + SignUp.newuser.user_id);
            }
            if (LogIn.newUser.Email != null && SignUp.newuser.Email == null)
            {
                Console.WriteLine("Email-Id : " + LogIn.newUser.Email);
            }
            else
            {
                Console.WriteLine("Email_Id : " + SignUp.newuser.Email);
            }
            if (LogIn.newUser.password != null && SignUp.newuser.password == null)
            {
                Console.WriteLine("Paasword : " + LogIn.newUser.password);
            }
            else
            {
                Console.WriteLine("Password : " + SignUp.newuser.password);
            }

            Console.WriteLine("----------------------\n");

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
            Console.WriteLine("Add And Edit Your Personal Details:- \n");

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
                    sRepo.AddUser(user , id);
                    Console.WriteLine("User Deatils Added ! ");
                    Console.ReadKey();
                    return "AddAndEditUserDetails";
                case "9":
                    Console.WriteLine(id);
                    Console.WriteLine("Press Enter For Confirmation ");
                    Console.ReadLine();
                    sRepo.DeleteUser(id);
                    Console.WriteLine("Parent Table Is Deleted. So Child Tables Are Also Deleted ! ");
                    Console.ReadKey();
                    return "SignUp";
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
