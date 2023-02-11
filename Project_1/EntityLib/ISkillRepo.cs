
namespace EntityLib
{
    public interface ISkillRepo
    {
        List<Entities.Skill> GetSkills(Entities.User user);
        Entities.Skill AddSkills(Entities.User user , Entities.Skill skill);
    }
}
