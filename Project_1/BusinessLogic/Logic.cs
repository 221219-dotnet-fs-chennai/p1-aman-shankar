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
        public IEnumerable<User> GetAllUser()
        {
            return Mapper.Map(repo.GetAllUsers());
        }
    }
}
