using EntityLib.Entities;
using System.Text.RegularExpressions;

namespace Business_Logic
{
    public class Validation 
    {
        private TrainerDbContext context;
        public Validation(TrainerDbContext _context)
        {
            context = _context;
        }

        public bool CheckEmailExists(string email)
        {
            try
            {
                var t = context.Users.Where(item => item.Email == email).First();
                if (t.Email == email)
                {
                    return true;
                }
                else if (t.Email != email || t.Email == null)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("");
            }
            return false;
        }
        public bool CheckUserIdExists(string id)
        {
            try
            {
                var t = context.Users.Where(item => item.UserId == id).First();
                if (t.UserId == id)
                {
                    return true;
                }
                else if (t.UserId != id)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("");
            }
            return false;
        }
        public bool CheckUserExists(string email, string password , string id)
        {
            try
            {
                var trainer = context.Users.Where(item => item.Email == email).First();
                if (trainer.Email == email && trainer.Password == password && trainer.UserId == id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        /*public bool CheckIdEmailExists(string email, string user_id)
        {
            try { 
                var trainer = context.Users.Where(item => item.Email == email).First();
                if (trainer.Email == email && trainer.UserId == user_id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }*/
        public static bool EmailIsValid(string email)
        {
            if (email != null) {
                try
                {
                    string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
                    if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Typed Email {email} Is Not In Correct Format. Retry Again! ");
                    }
                }catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
        public static bool IsValidMobileNumber(string number)
        {
            if (number != null)
            {
                try
                {
                    string pattern = @"^[6-9]\d{9}$";
                    if (Regex.IsMatch(number, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }catch(RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
        public static bool IsValidPassword(string password)
        {
            if (password != null)
            {
                try
                {
                    string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
                    if (Regex.IsMatch(password, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Typed Password {password} Is Not IN Correct Format. Retry Again! \n > Must be of 8 character long. \n > Must include atleast an 'Uppercase' alphabet. \n > Must contain atleast a digit. ");
                    }
                }
                catch(ArgumentException e) 
                {
                    Console.WriteLine(e.Message);
                }
                catch(RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
        public static bool IsValidUserId(string user_id)
        {
            if (user_id != null)
            {
                try
                {
                    string pattern = @"^\d{3}$";
                    if (Regex.IsMatch(user_id, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Typed User_Id {user_id} Is Not IN Correct Format. Retry Again! \n > Must contains 3-Digits ");
                    }
                }catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
        public static bool IsValidPincode(string pincode)
        {
            if (pincode != null)
            {
                try
                {
                    string pattern = @"^\d{6}$";
                    if (Regex.IsMatch(pincode, pattern))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Typed Pincode {pincode} Is Not IN Correct Format. Retry Again! \n > Must contains 6-Digits ");
                    }
                }catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(RegexMatchTimeoutException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
    }
}
