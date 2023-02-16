using EntityLib;
using EF = EntityLib.Entities;
using Models;

namespace Business_Logic
{
    public class FilterLogic : IFilterLogic
    {
        IUserRepo<EF.User> _repo;
        public FilterLogic(IUserRepo<EF.User> repo)
        {
            _repo = repo;
        }
        public IEnumerable<GenderFilter> GetUserByGender(string? gender)
        {
            var filterTable = _repo.GetAllUsers().Where(f => f.Gender == gender);
            List<GenderFilter> genderFilters = new List<GenderFilter>();
            foreach(EF.User us in filterTable)
            {
                genderFilters.Add(new GenderFilter()
                {
                    gender = us.Gender,
                    first_name = us.FirstName,
                    middle_name = us.MiddleName,
                    last_name = us.LastName,
                    pincode = us.Pincode
                });
            }
            return genderFilters;
        }

        public IEnumerable<GenderFilter> GetUserByPincode(string? pincode)
        {
            var filterTable = _repo.GetAllUsers().Where(f => f.Pincode == pincode);
            List<GenderFilter> pincodeFilters = new List<GenderFilter>();
            foreach (EF.User us in filterTable)
            {
                pincodeFilters.Add(new GenderFilter()
                {
                    pincode = us.Pincode,
                    first_name = us.FirstName,
                    middle_name = us.MiddleName,
                    last_name = us.LastName,
                    gender = us.Gender
                });
            }
            return pincodeFilters;
        }
    }
}
