using System;
using System.Data;
using DataLayer;

namespace UI_Layer
{
    internal class SignUp : IMenu
    {
        public static User newuser = new User();
        private static string cs = $"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;";
        public static SQLRepo srepo = new SQLRepo(cs);

        public void Display()
        {
            Console.WriteLine("Please Enter Your Email, Password And Save It :- \n");
            Console.WriteLine("[1] Email : " + newuser.Email );
            Console.WriteLine("[2] Password : " + newuser.password );
            Console.WriteLine("[3] UserId : " + newuser.user_id );
            Console.WriteLine("[4] Save ");
            Console.WriteLine("[0] Back To Menu");
            Console.WriteLine("[e] Exit \n");
        }

        public string UserOption()
        {
            string cs = File.ReadAllText("D:/Revature/Project1/UI_Layer/ConnectionString.txt");
            Validation newValidation = new(cs);
            string userInput = Console.ReadLine();
            switch (userInput)
            { 
                case "1":
                    Console.Write("Please Enter Your Email : ");
                    try
                    {
                        newuser.Email = Console.ReadLine();
                        if (newValidation.EmailIsValid(newuser.Email))
                        {
                            if (newValidation.CheckEmailExists(newuser.Email))
                            {
                                Console.WriteLine("This Email Is Already Registered.Please Press Enter To Go Into The LogIn Page !");
                                Console.ReadLine();
                                return "LogIn";
                            }
                            else
                            {
                                return "SignUp";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Email Format Is Not Correct. Please Press Enter To Rewrite The Email ! ");
                            Console.ReadLine();
                            newuser.Email = "";
                            return "SignUp";
                        }
                        
                            
                    }catch(NoNullAllowedException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                case "2":
                    Console.Write("Please Enter Password : ");
                    newuser.password = Console.ReadLine();
                    if (newValidation.IsValidPassword(newuser.password))
                    {
                        return "SignUp";
                    }
                    else
                    {
                        Console.WriteLine("It should be of 8 digit including these (9-1,a-z,A-Z and special character). Press Enter to Retry");
                        Console.ReadLine();
                        newuser.password = "";
                        return "SignUp";
                    }
                case "3":
                    Console.WriteLine("Please Enter Your User_Id. IT SHOULD BE IN 3 DIGIT ! ");
                    newuser.user_id = Console.ReadLine();
                    if (newValidation.IsValidUserId(newuser.user_id))
                    {
                        if (newValidation.CheckUserIdExists(newuser.user_id))
                        {
                            Console.WriteLine("This ID Is Already Registered.Please Press Enter To Retry !");
                            Console.ReadLine();
                            return "SignUp";
                        }
                        else
                        {
                            return "SignUp";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter only three digit user_id. Press Enter to retry! ");
                        Console.ReadLine();
                        newuser.user_id = "";
                        return "SignUp";
                    }
                case "4":
                    //try {
                        if (newuser.Email == null || newuser.password == null) 
                        { 
                            return "SignUp"; 
                        }
                        else
                        {
                            srepo.AddSignUp(newuser);
                            //newuser.Email = "";
                            //newuser.password = "";
                            Console.WriteLine("Added New User ! ");
                        }
                    /*}
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press Enter To Continue");
                        Console.ReadKey();
                        return "LogIn";
                    }*/
                    return "AddAndEditUserDetails"; 
                case "0":
                    return "Menu";
                case "e":
                    return "Exit";
                default:
                    Console.WriteLine("Please Enter A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "SignUp";

            }
        }
    }
}
