namespace HelloCSharp
{
    public class User
    {
        public static void GreetUser(){
            Console.WriteLine("Plese enter your name : ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name} - {DateTime.Now}");
        }
    }
}