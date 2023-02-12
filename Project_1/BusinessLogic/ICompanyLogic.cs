using Models;

namespace Business_Logic
{
    public interface ICompanyLogic
    {
        public Company AddCompany(string? email, Company company);
        public IEnumerable<Company> GetCompanies(string? email);
        public void UpdateCompany(string? email, string? company, Company comp);
        public Company RemoveCompany(string? email, string? company);
    }
}
