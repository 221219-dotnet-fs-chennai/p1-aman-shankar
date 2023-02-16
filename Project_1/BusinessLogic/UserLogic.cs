using Models;
using datafirst = EntityLib.Entities;

namespace Business_Logic
{
    public class UserLogic : IUserLogic
    {
        IUserRepo<datafirst.User> _repo;
        public UserLogic(IUserRepo<datafirst.User> repo)
        {
            _repo = repo;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Mapper.Map(_repo.GetAllUsers());
        }
        public User GetUsersByUser_Email(string u)
        {
            var search = _repo.GetAllUsers().Where(r => r.Email == u).First();
            return Mapper.Map(search);
        }

        User IUserLogic.AddUser(User u)
        {
            return Mapper.Map(_repo.AddUser(Mapper.Map(u)));
        }
        User IUserLogic.RemoveUserByUser_Email(string u)
        {
            var deletedUser = _repo.RemoveUser(u);
            if (deletedUser != null)
                return Mapper.Map(deletedUser);
            else
                return null;
        }
        User IUserLogic.UpdateUser(string email, User u)
        {
            var user = (from usr in _repo.GetAllUsers()
                              where usr.Email == email
                              select usr).FirstOrDefault();
            if (user != null)
            {
               // user.UserId = u.user_id;
               // user.Email = u.Email;
                user.Password = u.password;
                user.FirstName = u.first_name;
                user.MiddleName = u.middle_name;
                user.LastName = u.last_name;
                user.Gender= u.gender;
                user.Pincode = u.pincode;
                user.Website = u.website;
               // user.MobileNumber = u.mobile_number;
                user.AboutMe = u.about_me;

                user = _repo.UpdateUser(user);
            }

            return Mapper.Map(user);
        }
    }
}
