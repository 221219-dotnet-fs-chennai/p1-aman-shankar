﻿using Models;
using EntityLib.Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = EntityLib.Entities.DbContext;

namespace EntityLib
{
    public class Repo : IRepo<Entities.User>
    {
        
        DbContext context = new DbContext();
        public List<Entities.User> GetAllUsers()
        {
            return context.Users.ToList();
        }
        /// <summary>
        /// Add the User into the User table in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the User which was added</returns>
        public Entities.User AddUser(Entities.User user)
        {
            context.Users.Add(user);// no need to add any sql INSERT query just call Add method and it will create INSERT query behind the scenes
            context.SaveChanges(); // this method will fire the query to DB and persist the changes
            return user;
        }
        public Entities.User RemoveUser(string user_id)
        {
            var search = context.Users.Where(user => user.UserId == user_id).FirstOrDefault();
            if (search != null)
            {
                context.Users.Remove(search);// this will generate DELETE query of Sql to be passed to Database
                context.SaveChanges();
            }
            return search;
        }

        public Entities.User UpdateUser(Entities.User user)
        {
            context.Users.Update(user);// this will generate UPDATE sql query to be passed to databse via ADO.Net
            context.SaveChanges();
            return user;
        }
    }
}
