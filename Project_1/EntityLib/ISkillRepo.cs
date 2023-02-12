using EntityLib.Entities;

namespace EntityLib
{
    public interface ISkillRepo
    {
        public IEnumerable<Skills> GetSkills();
        public void AddSkill(Skills skill);
        public Skills RemoveSkill(Skills skill);
        public void UpdateSkill(Skills skill);
    }
}
