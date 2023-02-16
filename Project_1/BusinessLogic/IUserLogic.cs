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
        User GetUsersByUser_Email(string email);
        /*IEnumerable<User> GetUsersByUser_Gender(string gender);
        User GetUsersByUser_Pincode(string pincode);*/
        /// <summary>
        /// Add user to the database
        /// </summary>
        /// <param name="u"></param>
        /// <returns>User Added</returns>
        User AddUser(User u);
        User RemoveUserByUser_Email(string email);
        User UpdateUser(string email, User u);
        //public bool UserLogin(string eMail, string pass);
    }
}
