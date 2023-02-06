using Models;
using EntityLib.Entities;

namespace EntityLib
{
    public class Repo : IRepo<Entities.User>
    {
        
        DbContext context = new DbContext();
        public List<Entities.User> GetAllUsers()
        {
            return context.Users.ToList();
        }
        /// <summary>
        /// Add the User into the User table in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the User which was added</returns>
        public Entities.User AddUser(Entities.User user)
        {
            context.Users.Add(user);// no need to add any sql INSERT query just call Add method and it will create INSERT query behind the scenes
            context.SaveChanges(); // this method will fire the query to DB and persist the changes
            return user;
        }
    }
}
