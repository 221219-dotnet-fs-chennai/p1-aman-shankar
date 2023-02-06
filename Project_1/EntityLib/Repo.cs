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
    }
}
