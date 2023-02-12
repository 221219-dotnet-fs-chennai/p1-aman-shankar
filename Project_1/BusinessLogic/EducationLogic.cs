using EntityLib;
using EF = EntityLib.Entities;
using Models;

namespace Business_Logic
{
    public class EducationLogic : IEducationLogic
    {
        IUserLogic userLogic;
        private readonly IEducationRepo _repo;
        public EducationLogic(IEducationRepo repo, IUserLogic userLogic)
        {
            _repo = repo;
            this.userLogic = userLogic;
        }
        public Education AddEducation(string? email, Education education)
        {
            education.education_id = userLogic.GetUsersByUser_Email(email).user_id;
            var entityEducation = Mapper.Map(education);
            _repo.AddEducation(entityEducation);
            return Mapper.Map(entityEducation);
        }

        public IEnumerable<Education> GetEducations(string? email)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                List<EF.EducationDetail> educations = _repo.GetEducations().Where(e => e.EducationId == id).ToList();
                return Mapper.Map(educations);
            }
            catch (Exception)
            {
                throw new Exception("Email Does Not Exist!");
            }
        }

        public Education RemoveEducation(string? email, string? education)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                var search = _repo.GetEducations().Where(a => a.EducationId == id && a.EducationName == education).First();
                return Mapper.Map(_repo.RemoveEducation(search));
            }
            catch (Exception)
            {
                throw new Exception("Email Or Skill Does Not Match! ");
            }
        }

        public void UpdateEducation(string? email, string? education, Education edu)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                EF.EducationDetail entityEducation = _repo.GetEducations().Where(e => e.EducationId == id && e.EducationName == education).First();
                if (entityEducation != null)
                {
                    if (edu.education_name != "string" && entityEducation.EducationName != edu.education_name)
                    {
                        entityEducation.EducationName = edu.education_name;
                    }
                    if(edu.grade != "string" && entityEducation.Grade != edu.grade)
                    {
                        entityEducation.Grade = edu.grade;
                    }
                    if(edu.institute_name != "string" && entityEducation.InstituteName!= edu.institute_name)
                    {
                        entityEducation.InstituteName = edu.institute_name;
                    }
                    if(edu.duration != "string" && entityEducation.Duration != edu.duration)
                    {
                        entityEducation.Duration = edu.duration;
                    }
                    _repo.UpdateEducation(entityEducation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
