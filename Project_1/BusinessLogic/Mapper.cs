using System;
using Models;
using Data = EntityLib.Entities;

namespace Business_Logic
{
    public class Mapper
    {
        /// <summary>
        /// This method converts Models' User object to Entity Framework User Entity
        /// </summary>
        /// <param name="u"></param>
        /// <returns>Models.User</returns>
        public static Models.User Map(Data.User u)
        {
            return new Models.User()
            {
                user_id = u.UserId,
                first_name = u.FirstName,
                middle_name = u.MiddleName,
                last_name = u.LastName,
                gender = u.Gender,
                pincode = u.Pincode,
                Email= u.Email,
                website = u.Website,
                mobile_number = u.MobileNumber,
                password= u.Password,
                about_me = u.AboutMe
            };
        }
        /// <summary>
        /// This method converts Entity Framework User Entity to Models' Company object
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Data.User</returns>
        public static Data.User Map(Models.User u)
        {
            return new Data.User()
            {
                UserId = u.user_id,
                FirstName = u.first_name,
                MiddleName = u.middle_name,
                LastName = u.last_name,
                Gender = u.gender,
                Pincode = u.pincode,
                Email = u.Email,
                Website = u.website,
                MobileNumber = u.mobile_number,
                Password = u.password,
                AboutMe = u.about_me
            };
        }
        /// <summary>
        /// This method converts Models' Company object to Entity Framework Company Entity
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Models.Company</returns>
        public static Models.Company Map(Data.Company c)
        {
            return new Models.Company()
            {
                c_id = c.CId,
                company_id= c.CompanyId,
                company_name = c.CompanyName,
                industry = c.Industry,
                duration = c.Duration
            };
        }
        /// <summary>
        /// This method converts Entity Framework Company Entity to Models' Company object
        /// </summary>
        /// <param name="c"></param>
        /// <returns>Data.Company</returns>
        public static Data.Company Map(Models.Company c)
        {
            return new Data.Company()
            {
                CId = c.c_id,
                CompanyId = c.company_id,
                CompanyName = c.company_name,
                Industry = c.industry,
                Duration = c.duration
            };
        }
        /// <summary>
        /// This method converts Models' Skills object to Entity Framework Skill Entity
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Models.Skills</returns>
        public static Models.Skills Map(Data.Skills s)
        {
            return new Models.Skills()
            {
                s_id = s.SId,
                skill_id = s.SkillId,
                skill_name = s.SkillName
            };
        }
        /// <summary>
        /// This method converts Entity Framework Skills Entity to Models' Company object
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Data.Skills</returns>
        public static Data.Skills Map(Models.Skills s)
        {
            return new Data.Skills()
            {
                SId = s.s_id,
                SkillId = s.skill_id,
                SkillName = s.skill_name
            };
        }
        /// <summary>
        /// This method converts Models' Education object to Entity Framework EducationDetails Entity
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Models.Education</returns>
        public static Models.Education Map(Data.EducationDetail e)
        {
            return new Models.Education()
            {
                e_id = e.EId,
                education_id = e.EducationId,
                education_name = e.EducationName,
                institute_name = e.InstituteName,
                grade = e.Grade,
                duration = e.Duration
            };
        }
        /// <summary>
        /// This method converts Entity Framework Education Entity to Models' Company object
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Data.Education</returns>
        public static Data.EducationDetail Map(Models.Education e)
        {
            return new Data.EducationDetail()
            {
                EId = e.e_id,
                EducationId = e.education_id,
                EducationName = e.education_name,
                InstituteName = e.institute_name,
                Grade = e.grade,
                Duration = e.duration
            };
        }
        public static IEnumerable<Models.User> Map(IEnumerable<Data.User> users)
        {
            return users.Select(Map);
        }
        public static IEnumerable<Data.User> Map(IEnumerable<Models.User> users)
        {
            return users.Select(Map);
        }
        public static IEnumerable<Models.Skills> Map(IEnumerable<Data.Skills> skills)
        {
            return skills.Select(Map);
        }
        public static IEnumerable<Data.Skills> Map(IEnumerable<Models.Skills> skills)
        {
            return skills.Select(Map);
        }
        public static IEnumerable<Models.Education> Map(IEnumerable<Data.EducationDetail> educations)
        {
            return educations.Select(Map);
        }
        public static IEnumerable<Data.EducationDetail> Map(IEnumerable<Models.Education> educations)
        {
            return educations.Select(Map);
        }
        public static IEnumerable<Models.Company> Map(IEnumerable<Data.Company> companies)
        {
            return companies.Select(Map);
        }
        public static IEnumerable<Data.Company> Map(IEnumerable<Models.Company> companies)
        {
            return companies.Select(Map);
        }
    }
}
