using Models;

namespace Business_Logic
{
    public interface IEducationLogic
    {
        public Education AddEducation(string? email, Education education);
        public IEnumerable<Education> GetEducations(string? email);
        public void UpdateEducation(string? email,string? education, Education edu);
        public Education RemoveEducation(string? email , string? education);

    }
}
