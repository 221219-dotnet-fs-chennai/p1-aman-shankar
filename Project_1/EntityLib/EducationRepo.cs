using EntityLib.Entities;

namespace EntityLib
{
    public class EducationRepo : IEducationRepo
    {
        private readonly TrainerDbContext _context;

        public EducationRepo(TrainerDbContext context)
        {
            _context = context;
        }
        public void AddEducation(EducationDetail education)
        {
            _context.EducationDetails.Add(education);
            _context.SaveChanges();
        }

        public IEnumerable<EducationDetail> GetEducations()
        {
            return _context.EducationDetails.ToList();
        }

        public EducationDetail RemoveEducation(EducationDetail education)
        {
            _context.EducationDetails.Remove(education);
            _context.SaveChanges();
            return education;
        }

        public void UpdateEducation(EducationDetail education)
        {
            _context.Update(education);
            _context.SaveChanges();
        }
    }
}
