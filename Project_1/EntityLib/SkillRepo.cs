using EntityLib.Entities;

namespace EntityLib
{
    public class SkillRepo : ISkillRepo
    {
        private readonly TrainerDbContext _context;
        public SkillRepo(TrainerDbContext context)
        {
            _context = context;
        }
        public Skill AddSkills(User user, Skill skill)
        {
            _context.Skills.Add(new Skill()
            {
                SkillId = skill.SkillId,
                SId = skill.SId,
                SkillName = skill.SkillName,
            }
            );
            _context.SaveChanges();
            return skill;
        }
        public List<Skill> GetSkills(Entities.User user)
        {
            return _context.Skills.Where(x => x.SkillId == user.UserId).ToList();
        }
    }
}
