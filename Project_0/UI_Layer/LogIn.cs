﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Layer
{
    internal class LogIn : IMenu
    {
        public static User newUser= new User();
        static string conStr = $"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;";
        public static User us = new User();
        public void Display()
        {
            Console.WriteLine("Please Enter Your Registered Email-Id And Password To Login :- \n");
            Console.WriteLine("[1] Email :- " + newUser.Email);
            Console.WriteLine("[2] User_Id :- " +newUser.user_id);
            Console.WriteLine("[3] Password :- " + newUser.password);
            Console.WriteLine("[4] LogIn ");
            Console.WriteLine("[0] Back ");
            Console.WriteLine("[e] Exit \n");
        }

        public string UserOption()

        {
            string e = "";
            string p = "";
            string cs = $"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;";
            Validation newValidation = new(conStr);
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Write("Please Enter Your Registered Email : ");
                    
                    newUser.Email = Console.ReadLine();
                        if (newValidation.CheckEmailExists(newUser.Email))
                        {
                            e = newUser.Email;
                            return "LogIn";
                        }
                        else
                        {
                            Console.WriteLine("Email Is Not Correct. Please Press Enter To Rewrite Your Registered Email ! ");
                            Console.ReadLine();
                            newUser.Email = "";
                            return "LogIn";
                        }
                case"2":
                    Console.WriteLine("Please Enter Your Registered User_Id ");
                    newUser.user_id = Console.ReadLine();
                    if(newValidation.CheckEmailUserIdExists(newUser.Email , newUser.user_id))
                    {
                        return "LogIn";
                    }
                    else
                    {
                        Console.WriteLine("Email Or User_Id Doesn't Match . Please Write Correct Email And Password ");
                        Console.ReadLine();
                        newUser.user_id = "";
                        return "LogIn";
                    }
                case "3":
                    Console.Write("Please Enter Your Registered Password : ");
                    newUser.password = Console.ReadLine();
                    if (newValidation.IsValidPassword(newUser.password))
                    {
                        p = newUser.password;
                        return "LogIn";
                    }
                    else
                    {
                        Console.WriteLine("Invalid Password . Please");   //Doubt
                        return "LogIn";
                    }
                case "4":
                    newValidation.CheckUserExists(e, p);
                    Console.WriteLine("done");
                    return "AddAndEditUserDetails";
                    /*if(newUser.Email != null && newUser.password != null)
                    {
                        if (newValidation.CheckUserExists(e, p))
                        {
                           
                            return "AddAndEditUserDetails";
                        }
                        else
                        {
                            Console.WriteLine("Email Or Password Doesn't Match . Please Write Correct Email And Password ");
                            Console.ReadLine();
                            return "LogIn";
                        }
                    }*/
                    
                case "0":
                    return "Menu";
                case "e":
                    return "Exit";
                default:
                    Console.WriteLine("Please Input A Valid Response");
                    Console.WriteLine("Please Press Enter To Continue");
                    Console.ReadLine();
                    return "LogIn";
            }
        }
    }
}
// Genric , Ado.net ,Delegate ,Exception , Regular Expression ,garbage collector 