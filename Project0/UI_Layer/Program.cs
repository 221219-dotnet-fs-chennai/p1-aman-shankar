using DataLayer;
using DataLayer;
using Serilog;
using UI_Layer;

class Program
{
    public static void Main (string[] args)
    {
       /* 
       ISqlRepo<User> sqlRepo = new UserTable("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //User us = new User(4,"Manoj","soni","Kumar","Male","675423","majoj213@gmail.com","http:manoj.com","987123450","Manoj123","Hacker");
        //sqlRepo.Add(us);

        sqlRepo.Get().ForEach(user => Console.WriteLine(user));
        //sqlRepo.Get().ForEach(skill => Console.WriteLine(skill));
        //sqlRepo.Get().ForEach(company => Console.WriteLine(company));
        //sqlRepo.Get().ForEach(education_details => Console.WriteLine(education_details));

        /*
        Company com = new Company(3, "Wipro", "Senior Developer", "1 Year and 9 Months");
        Skills sk = new Skills(3, "C#");
        Education_Details ed = new Education_Details(1, "12th", "Chadighar Higher secondary School", "A", "2 Years");
        */

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
                    Log.Information("Displaying Personal Details ");
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
