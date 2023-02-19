using EF = EntityLib.Entities;
using Models;
using EntityLib.Entities;

namespace EntityLib
{
    public class UserLogin_Repo : IUserLogin_Repo
    {
        TrainerDbContext context = new TrainerDbContext();
        public bool UserLogin(string eMail, string pass , string id)
        {
            var result = context.Users;
            var query = result.FirstOrDefault(e => e.Email == eMail);

            if (query != null)
            {
                var query1 = result.FirstOrDefault(p => p.Password == pass);
                var query2 = result.FirstOrDefault(i => i.UserId == id);
                if(query1 != null && query2 != null)
                {
                    Console.WriteLine("Trainer Login !");
                    return true;
                }
                else
                {
                    Console.WriteLine("\n Wrong Password ! Please Retry.... \n Press Enter To Continue....");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("\n No Data Found In This Email. \n Please Check Your Credentails First! ");
                return false;
            }
        }
    }
}
