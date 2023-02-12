using EntityLib;
using EF = EntityLib.Entities;
using Models;

namespace Business_Logic
{
    public class CompanyLogic : ICompanyLogic
    {
        IUserLogic userLogic;
        private readonly ICompanyRepo _repo;
        public CompanyLogic(ICompanyRepo repo , IUserLogic userLogic)
        {
            _repo = repo;
            this.userLogic = userLogic;
        }
        public Company AddCompany(string? email, Company company)
        {
            company.company_id = userLogic.GetUsersByUser_Email(email).user_id;
            var entityCompany = Mapper.Map(company);
            _repo.AddCompany(entityCompany);
            return Mapper.Map(entityCompany);
        }

        public IEnumerable<Company> GetCompanies(string? email)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                List<EF.Company> companies = _repo.GetCompanies().Where(c => c.CompanyId == id).ToList();
                return Mapper.Map(companies);
            }
            catch (Exception)
            {
                throw new Exception("Email Does Not Exist!");
            }
        }

        public Company RemoveCompany(string? email, string? company)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                var search = _repo.GetCompanies().Where(a => a.CompanyId == id && a.CompanyName == company).First();
                return Mapper.Map(_repo.RemoveCompany(search));
            }
            catch (Exception)
            {
                throw new Exception("Email Or Company Does Not Match! ");
            }
        }

        public void UpdateCompany(string? email, string? company, Company comp)
        {
            try
            {
                string id = userLogic.GetUsersByUser_Email(email).user_id;
                EF.Company entityCompany = _repo.GetCompanies().Where(s => s.CompanyId == id && s.CompanyName == company).First();
                if (entityCompany != null)
                {
                    if (comp.company_name != "string" && entityCompany.CompanyName != comp.company_name)
                    {
                        entityCompany.CompanyName = comp.company_name;
                    }
                    if(comp.industry != "string" && entityCompany.Industry!= comp.industry)
                    {
                        entityCompany.Industry= comp.industry;
                    }
                    if(comp.duration != "string" && entityCompany.Duration != comp.duration)
                    {
                        entityCompany.Duration = comp.duration;
                    }
                    _repo.UpdateCompany(entityCompany);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
