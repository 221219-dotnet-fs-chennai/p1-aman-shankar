using Models;
using EntityLib;
using datafirst = EntityLib.Entities;

namespace Business_Logic
{
    public class UserLogin_Logic : IUserLogin_Logic
    {
        IUserLogin_Repo _repo;
        public UserLogin_Logic(IUserLogin_Repo repo)
        {
            _repo = repo;
        }
        public bool UserLogin(string eMail, string pass, string id)
        {
            return _repo.UserLogin(eMail, pass , id);
        }
        
    }
}
