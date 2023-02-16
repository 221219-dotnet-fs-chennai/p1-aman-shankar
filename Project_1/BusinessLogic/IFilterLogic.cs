using Models;

namespace Business_Logic
{
    public interface IFilterLogic
    {
        IEnumerable<GenderFilter> GetUserByGender(string? gender);
        IEnumerable<GenderFilter> GetUserByPincode(string? pincode);
    }
}
