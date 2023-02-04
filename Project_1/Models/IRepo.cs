﻿using System.Collections.Generic;
namespace Models
{
    public interface IRepo<T>
    {
/*
        /// <summary>
        /// Add the User into the User.json File
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the Restaurant which was added</returns>
        T Add(T user);
*/

        /// <summary>
        /// Will return all users in the User.json file
        /// </summary>
        /// <returns>List of all users objects in the collection of Type List<User></returns>
        List <T> GetAllUsers();
    }
}
