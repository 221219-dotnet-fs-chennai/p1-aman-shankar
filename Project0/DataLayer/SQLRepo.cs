using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SQLRepo
    {
        private readonly string conStr;
        public SQLRepo(string conStr)
        {
            this.conStr = conStr;
        }

        //Get Methods OF All Tables.....................................................
        public List<User> GetUser(string user_id)
        {
            List<User> users = new List<User>();
            using SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = $"SELECT [first_name],[middle_name],[last_name],[gender],[pincode],[website],[mobile_number],[about_me] FROM [User] WHERE [user_id] = '{user_id}';";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User()
                {
                    first_name = reader.GetString(0),
                    middle_name = reader.GetString(1),
                    last_name = reader.GetString(2),
                    gender = reader.GetString(3),
                    pincode = reader.GetString(4),
                    website = reader.GetString(5),
                    mobile_number = reader.GetString(6),
                    about_me = reader.GetString(7),
                });
            }
            return users;
        }
        public List<Skills> GetSkills(string skill_id)
        {
            List<Skills> skills = new List<Skills>();
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            string query = $"SELECT [skill_name] FROM [Skills] WHERE [skill_id] = {skill_id}";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                skills.Add(new Skills()
                {
                    skill_name = reader.GetString(0),
                });
            }
            return skills;
        }
        public List<Education> GetEducation(string education_id)
        {
            List<Education> education_details = new
                ();
            using SqlConnection con = new SqlConnection("$\"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;\";");
            con.Open();
            string query = $"SELECT [education_name],[institute_name],[grade],[duration] FROM [Education_Details] WHERE [education_id] = {education_id};";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                education_details.Add(new Education()
                {
                    education_name = reader.GetString(0),
                    institute_name = reader.GetString(1),
                    grade = reader.GetString(2),
                    duration = reader.GetString(3),

                });
            }
            return education_details;
        }
        public List<Company> GetCompany(string company_id)
        {
            List<Company> company = new();
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            string query = $"SELECT [company_id],[company_name],[industry],[duration] FROM [Company] WHERE [company_id] = {company_id};";
            SqlCommand command = new SqlCommand(query, con);
            // for executing
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                company.Add(new Company()
                {
                    company_id = reader.GetString(0),
                    company_name = reader.GetString(1),
                    industry = reader.GetString(2),
                    duration = reader.GetString(3),
                });
            }
            return company;
        }

        //Inserting And Updating ...........................................................

        public void AddSignUp(User user)
        {
            string query = "INSERT INTO [User]([user_id],[Email],[password])VALUES(@id,@email,@password);";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", user.user_id);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@password", user.password);
            command.ExecuteNonQuery();
        }

        public User AddUser(User user, string id)   
        {
            string query = $"UPDATE [User] SWT [first_name] = @first_name , [middle_name] = @middle_name , [last_name] = @last_name , [gender] = @gender , [pincode] =  @pincode , [website] =  @website , [mobile_number] =  @mobile_number , [about_me] = @about_me  WHERE [user_id] = '{id}';";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@first_name", user.first_name);
            command.Parameters.AddWithValue("@middle_name", user.middle_name);
            command.Parameters.AddWithValue("@last_name", user.last_name);
            command.Parameters.AddWithValue("@gender", user.gender);
            command.Parameters.AddWithValue("@pincode", user.pincode);
            command.Parameters.AddWithValue("@website", user.website);
            command.Parameters.AddWithValue("@mobile_number", user.mobile_number);
            command.Parameters.AddWithValue("@about_me", user.about_me);
            command.ExecuteNonQuery();
            Console.WriteLine("User_Details Added ! ");
            return user;
        }
        public void AddSkills(Skills skills)
        {
            while(skills != null)
            {
                string query = "INSERT INTO [Skills]([skill_id], [skill_name]) VALUES (@id, @skill_name )";
                using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@id", skills.skill_id);
                command.Parameters.AddWithValue("@skill_name", skills.skill_name);
                command.ExecuteNonQuery();
            }
            
        }
        public void AddEducation(Education education_details)
        {
            string query = "INSERT INTO [Education_Details]([education_name],[institute_name],[grade],[duration]) VALUES (@education_name,@institute_name,@grade,@duration)";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            command.Parameters.AddWithValue("@education_name", education_details.education_name);
            command.Parameters.AddWithValue("@institute_name", education_details.institute_name);
            command.Parameters.AddWithValue("@grade", education_details.grade);
            command.Parameters.AddWithValue("@duration", education_details.duration);
            command.ExecuteNonQuery();
        }
        public void AddCompany(Company company)
        {
            string query = "INSERT INTO [Company]([company_name],[industry],[duration]) VALUES (@company_id,@company_name,@industry,@duration)";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            //command.Parameters.AddWithValue("@company_id", company.company_id);
            command.Parameters.AddWithValue("@company_name", company.company_name);
            command.Parameters.AddWithValue("@industry", company.industry);
            command.Parameters.AddWithValue("@duration", company.duration);
            command.ExecuteNonQuery();
        }

        //Delete ......................................................................................
        public void DeleteUser(string user )
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {user};";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void DeleteSkills(string skill)
        {
            string query = $"DELETE FROM [User] WHERE [skill_id] = {skill}";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void DeleteEducation(string edu)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {edu}";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void DeleteCompany(string comp)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {comp}";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }

        //Update ...............................................................................................................
        
        /*public void UpdateUser(User newU, User oldU, User id)  //not completed
        {
            string query = $"Update [User] SET [first_name] = '{newU}' WHERE '{oldU}' AND [user_id] = {id};";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }*/
        
        public void UpdateSkills(Skills newS, Skills oldS, Skills id)
        {
            string query = $"Update [Skills] SET [skill_name] = '{newS}' WHERE [skill_name] = '{oldS}' AND [skill_id] = {id};";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void UpdateEducation(Education newE, Education oldE, Education id) 
        {
            string query = $"Update [Education] SET [education_name] = '{newE}' WHERE [education_name] = '{oldE}' AND [education_id] = {id}";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void UpdateCompany(Company newC, Company oldC, Company id)
        {
            string query = $"Update [Company] SET [company_name] = '{newC}' WHERE [company_name] = '{oldC}' AND [company_id] = {id};";
            using SqlConnection con = new SqlConnection($"Server=DESKTOP-QONHH5T;Database=Project0;Trusted_Connection=True;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
    }
}
