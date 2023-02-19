using Models;
using EntityLib.Entities;

namespace EntityLib
{
    public interface IUserLogin_Repo
    {
        public bool UserLogin(string Email, string pass , string id);
    }
}
