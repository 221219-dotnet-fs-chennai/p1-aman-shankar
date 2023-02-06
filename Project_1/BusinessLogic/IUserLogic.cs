using Models;

namespace Business_Logic
{
    public interface IUserLogic
    {
        /// <summary>
        /// This method will return all the users been queried from the Data Logic
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllUsers();
    }
}
