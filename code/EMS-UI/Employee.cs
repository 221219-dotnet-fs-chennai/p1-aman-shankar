namespace EMS_UI
{
    public class Employee
    {
        string firstName = "Lilly";
        public string lastName = "Windsor" , id = "101";

        // properties is another  way to represent encapsulation
        public string FirstName{
            //readable accessor
            get{
                return firstName;
            }
            //write accessor
            set {
                firstName = value;
            }
            //to assign a new value only during object construction
            //init ;

        }
        int age = 25;
        char code = '1';
        bool isAlive = true;
         public Employee(){
            firstName ="Lilly";
         }
         public Employee(string firstName , string lastName){
            this.firstName ="Lilly";
         }
    }
}