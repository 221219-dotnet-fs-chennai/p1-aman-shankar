using Models;
using datafirst = EntityLib.Entities;

namespace Business_Logic
{
    public class UserLogic : IUserLogic
    {
        IRepo<datafirst.User> _repo;
        public UserLogic(IRepo<datafirst.User> repo)
        {
            _repo = repo;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Mapper.Map(_repo.GetAllUsers());
        }

        User IUserLogic.AddUser(User u)
        {
            return Mapper.Map(_repo.AddUser(Mapper.Map(u)));
        }
    }
}
