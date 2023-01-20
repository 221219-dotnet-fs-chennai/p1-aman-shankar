using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace UI_Layer
{
    internal class Validation
    {
        private readonly string connectionString;
        public Validation(string connectionString)
        {
            this.connectionString = connectionString;
        }
        internal bool CheckEmailExists(string email)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "SELECT [Email] FROM [User]";
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    List<string> list = new List<string>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                    while (list.Count > 0)
                    {
                        if (list.Contains(email))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        internal bool CheckUserIdExists(string id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            try {
                con.Open();
                string query = "SELECT [user_id] FROM [User]";
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    List<string> list = new List<string>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                    while (list.Count > 0) 
                    {
                        if (list.Contains(id))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        internal bool CheckUserExists(string email, string password)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "SELECT [Email],[password] FROM [User]";
                SqlCommand command = new(query, con);
                try
                {
                    Dictionary<string , string> dictionary= new Dictionary<string , string>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if(!dictionary.ContainsKey(reader.GetString(0))) dictionary.Add(reader.GetString(0), reader.GetString(1));
                    }
                    while (dictionary.Count > 0)
                    {
                        return dictionary.Any(Entry => Entry.Key == email && Entry.Value == password);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        internal bool CheckEmailUserIdExists(string email , string user_id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string query = "SELECT [Email],[user_id] FROM [User]";
                SqlCommand command = new(query, con);
                try
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!dictionary.ContainsKey(reader.GetString(0))) dictionary.Add(reader.GetString(0), reader.GetString(1));
                    }
                    while (dictionary.Count > 0)
                    {
                        return dictionary.Any(Entry => Entry.Key == email && Entry.Value == user_id);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;

            /*int Id = 0;
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = $"SELECT [user_id] FROM [User] WHERE [Email] = '{email}';";
            SqlCommand command = new SqlCommand(query, con);
            Id = Convert.ToInt32(command.ExecuteScalar());
            return Id;*/
        }
        internal bool EmailIsValid(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }
        internal bool IsValidNumber(string number)
        {
            string pattern = @"[6-9]\d{9}";
            if(Regex.IsMatch(number , pattern))
            {
                return true;
            }else
            {
                return false;
            }
        }
        internal bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
            if (Regex.IsMatch(password , pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool IsValidUserId(string user_id)
        {
            string pattern = @"^[0-9]{3}$";
            if (Regex.IsMatch(user_id, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool IsValidPincode(string pincode)
        {
            string pattern = @"\d{6}";
            if (Regex.IsMatch(pincode, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
