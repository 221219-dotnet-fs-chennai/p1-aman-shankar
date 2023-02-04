using DataLayer;
using DataLayer;
using Serilog;
using UI_Layer;

class Program
{
    public static void Main (string[] args)
    {
        string path = "D:/Revature/Project1/UI_Layer/Database/log.txt";
        if (!File.Exists(path))
            File.Create(path);
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(path, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
            .CreateLogger();
        Log.Logger.Information("----Program starts----");

        bool repeat = true;
        IMenu menu = new Menu();
        while(repeat)
        {
            Console.Clear();
            menu.Display();
            string ans = menu.UserOption();
            switch(ans)
            {
                case "Menu":
                    Log.Information("Displaying Main Menu To User ");
                    menu = new Menu();
                    break;
                case "SignUp":
                    Log.Information("Displaying SignUp To User ");
                    menu = new SignUp();
                    break;
                case "LogIn":
                    Log.Information("Displaying LogIn To User ");
                    menu = new LogIn();
                    break;
                case "AddAndEditUserDetails":
                    Log.Information("Displaying Adding And Editing User Details ");
                    menu = new AddAndEditUserDetails();
                    break;
                case "Personal_Details":
                    Log.Information("Displaying Personal Details ");
                    menu = new Personal_Details();
                    break;
                case "Skills_Details":
                    Log.Information("Displaying Skills Details ");
                    menu = new Skills_Details();
                    break;
                case "Education_Details":
                    Log.Information("Displaying Education Details ");
                    menu = new Education_Details();
                    break;
                case "Experience_In_Companies":
                    Log.Information("Displaying Experience_In_Companies Details ");
                    menu = new Experience_In_Companies();
                    break;
                
                case "Exit":
                    Log.Information("Exiting Application");
                    Log.Logger.Information("----Program Ends----");
                    Log.CloseAndFlush(); //To close our logger resource
                    repeat = false;
                    break;
                default:
                    Console.WriteLine("Page Does Not Exist !");
                    Console.WriteLine("Please Press Enter To Continue !");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
