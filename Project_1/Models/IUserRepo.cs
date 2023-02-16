namespace Models
{
    public interface IUserRepo<T>
    {

        /// <summary>
        /// Add the User into the User.json File
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the User which was added</returns>
        T AddUser(T user);
        /// <summary>
        /// Will return all users in the User.json file
        /// </summary>
        /// <returns>List of all Users objects in the collection of Type List<User></returns>
        List<T> GetAllUsers();
        /// <summary>
        /// Removes the the given user from the database by searching for the user by name
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Returns the User which is removed from the users table</returns>
        T RemoveUser(string email);
        /// <summary>
        /// Updates the information about the user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>updated User</returns>
        T UpdateUser(T user);
       // bool UserLogin(string eMail, string pass);

        /*/// <summary>
        /// Adding signup details
        /// </summary>
        /// <param name="_data"></param>
        T AddUserSignUp(T _data);*/

    }
}
