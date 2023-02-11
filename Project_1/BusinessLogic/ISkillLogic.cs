using Models;

namespace Business_Logic
{
    public interface ISkillLogic
    {
        Skills AddSkills(User user ,Skills skill);
        IEnumerable<Skills> GetSkills(User user);
    }
}
