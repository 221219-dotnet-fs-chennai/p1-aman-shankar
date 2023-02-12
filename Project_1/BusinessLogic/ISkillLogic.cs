using Models;

namespace Business_Logic
{
    public interface ISkillLogic
    {
        public Skills AddSkill(string? email,Skills skill);
        public IEnumerable<Skills> GetSkill(string? email);
        public void UpdateSkill(string? email , string? skill, Skills skills);
        public Skills RemoveSkill(string? email , string? skill);
    }
}
