using EntityLib;
using EF = EntityLib.Entities;
using Models;

namespace Business_Logic
{
    public class SkillLogic : ISkillLogic
    {
        IUserLogic userLogic;
        private readonly ISkillRepo _repo;
        public SkillLogic(ISkillRepo repo, IUserLogic userLogic)
        {
            _repo = repo;
            this.userLogic = userLogic;
        }
        public Skills AddSkill(string? email , Skills skill)
        {
            skill.skill_id = userLogic.GetUsersByUser_Email(email).user_id;
            var entitySkill = Mapper.Map(skill);
            _repo.AddSkill(entitySkill);
            return Mapper.Map(entitySkill);
        }
        public IEnumerable<Skills> GetSkill(string? email)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                List<EF.Skills> skills = _repo.GetSkills().Where(c => c.SkillId== id).ToList();
                return Mapper.Map(skills);
            }
            catch (Exception )
            {
                throw new Exception("Email Does Not Exist!");
            }
        }

        public void UpdateSkill(string? email,string? skill, Skills skills)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                EF.Skills entitySkill = _repo.GetSkills().Where(s => s.SkillId == id && s.SkillName== skill).First();
                //var entitySkill = _repo.RemoveSkill(_entitySkill);
                //skills.s_id = entitySkill.SId;
                if(entitySkill != null)
                {
                    if(skills.skill_name != "string" && entitySkill.SkillName != skills.skill_name)
                    {
                        entitySkill.SkillName = skills.skill_name;
                    }
                    _repo.UpdateSkill(entitySkill);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Skills RemoveSkill(string? email, string? skill)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                var search = _repo.GetSkills().Where(a => a.SkillId == id && a.SkillName == skill).First();
                return Mapper.Map(_repo.RemoveSkill(search));
            }
            catch (Exception)
            {
                throw new Exception("Email Or Skill Does Not Match! ");
            }
        }
    }
}
