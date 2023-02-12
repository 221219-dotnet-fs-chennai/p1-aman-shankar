using EntityLib.Entities;

namespace EntityLib
{
    public interface ICompanyRepo
    {
        public IEnumerable<Company> GetCompanies();
        public void AddCompany(Company company);
        public Company RemoveCompany(Company company);
        public void UpdateCompany(Company company);
    }
}
