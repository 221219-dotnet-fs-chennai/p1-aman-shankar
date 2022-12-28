// Single line comment
/*
- dotnet new console -o HelloCSharp -lang C# (for creating a file in the folder)
- Extension (we download C#)
- If you are in the same folder then ok otherwish cd foldername/
- dotnet build (for compiling)
- cd foldername/ then dotnet run (for run)
- If you change anything in the program then save , then dotnet build and then dotnet run.
*/
// Console is a predefined class, Writeline -> is a method of Console class which prints the string wriiten inside
/*


*/
/*
Console.WriteLine("Please enter your name" );
string name = Console.ReadLine();
// Console.WriteLine("Hello" + name);
Console.WriteLine($"Hello {name}");
*/

 //previos verion of .Net 6 the program structure looks like below
 namespace HelloCSharp{
	//Type - class,struct , enums , interface , delegates
    class Program{
        //Type Members - Eg:- Method , properties , fields/variables , constructor
        public static void Main(string[] args){  //Execution stating point of the program for exe. (string[] args) = Command Argumment
            Console.WriteLine("Hello World"); 
            // Console.WriteLine(args[0]); // Printing 1st command line arrgument
            User.GreetUser();
        }
    }
}


