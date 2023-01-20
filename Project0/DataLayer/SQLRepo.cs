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
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            string query = $"SELECT [skill_name] FROM [Skills] WHERE [skill_id] = {skill_id};";
            SqlCommand command = new SqlCommand(query, con);
            // for executing
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
            List<Education> education_details = new();
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

        //Adding Or Inserting...........................................................

        public void AddSignUp(User user)
        {
            string query = "INSERT INTO [User]([user_id],[Email],[password])VALUES(@id,@email,@password);";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@id", user.user_id);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@password", user.password);
            command.ExecuteNonQuery();
        }

        public void AddUser(User user)
        {
            string query = "INSERT INTO [User]([first_name],[middle_name],[last_name],[gender],[pincode],[website],[mobile_number],[about_me])VALUES(@first_name,@middle_name,@last_name,@gender,@pincode,@website,@mobile_number,@about_me)";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
        }
        public void AddSkills(Skills skills)
        {
            string query = "INSERT INTO [Skills]([skill_name]) VALUES (@skill_name )";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            //command.Parameters.AddWithValue("@skill_id", skills.skill_id);
            command.Parameters.AddWithValue("@skill_name", skills.skill_name);
            command.ExecuteNonQuery();
        }
        public void AddEducation(Education education_details)
        {
            string query = "INSERT INTO [Education_Details]([education_name],[institute_name],[grade],[duration]) VALUES (@education_name,@institute_name,@grade,@duration)";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            //command.Parameters.AddWithValue("@company_id", company.company_id);
            command.Parameters.AddWithValue("@company_name", company.company_name);
            command.Parameters.AddWithValue("@industry", company.industry);
            command.Parameters.AddWithValue("@duration", company.duration);
            command.ExecuteNonQuery();
        }

        //Delete ......................................................................................
        public void Delete(User user)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {user}";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Delete(Skills skill)
        {
            string query = $"DELETE FROM [User] WHERE [skill_id] = {skill}";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Delete(Education edu)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {edu}";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Delete(Company comp)
        {
            string query = $"DELETE FROM [User] WHERE [user_id] = {comp}";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }

        //Update ...............................................................................................................
        public void Update(User newU, User oldU, User id)  //not completed
        {
            string query = $"Update [User] SET [first_name] = '{newU}' WHERE '{oldU}' [user_id] = {id};";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        
        public void Update(Skills newS, Skills oldS, Skills id)
        {
            string query = $"Update [Skills] SET [skill_name] = '{newS}' WHERE '{oldS}' [skill_id] = {id};";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Update(Education newE, Education oldE, Education id) 
        {
            string query = $"Update [Education] SET [education_name] = '{newE}' WHERE [education_name] = '{oldE}' AND [education_id] = {id}";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        public void Update(Company newC, Company oldC, Company id)
        {
            string query = $"Update [Company] SET [company_name] = '{newC}' WHERE [company_name] = '{oldC}' AND [company_id] = {id};";
            using SqlConnection con = new SqlConnection("Server=tcp:aman-shankar-db.database.windows.net,1433;Initial Catalog=Project1;Persist Security Info=False;User ID=Aman;Password=Ananta123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
    }
}
