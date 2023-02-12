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
        public void AddSkill(Skills skills)
        {
            _context.Skills.Add(skills);
            _context.SaveChanges();
        }

        public IEnumerable<Skills> GetSkills()
        {
            return _context.Skills.ToList();
        }

        public Skills RemoveSkill(Skills skill)
        {
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return skill;
        }

        public void UpdateSkill(Skills skill)
        {
            _context.Update(skill);
            _context.SaveChanges();
        }
    }
}
