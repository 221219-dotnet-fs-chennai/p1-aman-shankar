using Microsoft.EntityFrameworkCore.Migrations;
using Models;
using EF = EntityLib;

namespace Business_Logic
{
    public class Logic : ILogic
    {
        IRepo<EF.Entities.User> repo;
        public Logic()
        {
            repo = new EF.Repo();
        }
        IEnumerable<User> ILogic.GetAllUsers()
        {
            return Mapper.Map(repo.GellAllUsers());
        }
    }
}
