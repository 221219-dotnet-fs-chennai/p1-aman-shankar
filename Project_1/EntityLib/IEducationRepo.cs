using EntityLib.Entities;

namespace EntityLib
{
    public interface IEducationRepo
    {
        public IEnumerable<EducationDetail> GetEducations();
        public void AddEducation(EducationDetail education);
        public EducationDetail RemoveEducation(EducationDetail education);
        public void UpdateEducation(EducationDetail education);

    }
}
