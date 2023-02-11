using Microsoft.EntityFrameworkCore.Migrations;
using Models;
using EF = EntityLib;

namespace Business_Logic
{
    public class Logic : ILogic
    {
        IUserRepo<EF.Entities.User> repo;
        public Logic(IUserRepo<EF.Entities.User> repo)
        {
            this.repo = repo;
        }
        public IEnumerable<User> GetAllUser()
        {
            return Mapper.Map(repo.GetAllUsers());
        }
    }
}
