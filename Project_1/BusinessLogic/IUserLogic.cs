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
        /// <summary>
        /// Add user to the database
        /// </summary>
        /// <param name="u"></param>
        /// <returns>User Added</returns>
        User AddUser(User u);
        User RemoveUserByUser_Id(string u);
        User UpdateUser(string user_id, User u);
    }
}
