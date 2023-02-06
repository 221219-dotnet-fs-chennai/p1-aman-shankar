using System.Collections.Generic;
namespace Models
{
    public interface IRepo<T>
    {

        /// <summary>
        /// Add the User into the User.json File
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the Restaurant which was added</returns>
        T AddUser(T user);


        /// <summary>
        /// Will return all users in the User.json file
        /// </summary>
        /// <returns>List of all users objects in the collection of Type List<User></returns>
        List<T> GetAllUsers();
        /// <summary>
        /// Removes the the given user from the database by searching for the user by name
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns>Returns the user which is removed from the users table</returns>
        T RemoveUser(string user_id);
        /// <summary>
        /// Updates the information about the user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>updated user</returns>
        T UpdateUser(T user);
    }
}
