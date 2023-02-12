using EntityLib.Entities;

namespace EntityLib
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly TrainerDbContext _context;
        public CompanyRepo(TrainerDbContext context)
        {
            _context = context;
        }
        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company RemoveCompany(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return company;
        }

        public void UpdateCompany(Company company)
        {
            _context.Update(company);
            _context.SaveChanges();
        }
    }
}
