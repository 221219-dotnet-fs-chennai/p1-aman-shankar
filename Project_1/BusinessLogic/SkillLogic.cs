using EntityLib;
using Models;

namespace Business_Logic
{
    public class SkillLogic : ISkillLogic
    {
        private readonly ISkillRepo _repo;
        public SkillLogic(ISkillRepo repo)
        {
            _repo = repo;
        }
        public Skills AddSkills(User user ,Skills skill)
        {
            return Mapper.Map(_repo.AddSkills(Mapper.Map(user),Mapper.Map(skill)));
        }
        public IEnumerable<Skills> GetSkills(User user)
        {
            return Mapper.Map(_repo.GetSkills(Mapper.Map(user)));
        }
    }
}
