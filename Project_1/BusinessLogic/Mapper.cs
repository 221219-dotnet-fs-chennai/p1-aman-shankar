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
        /// This method converts Models' Skills object to Entity Framework Skill Entity
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Models.Skills</returns>
        public static Models.Skills Map(Data.Skill s)
        {
            return new Models.Skills()
            {
                s_id = s.SId,
                skill_id = s.SkillId,
                skill_name = s.SkillName
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
        public static IEnumerable<Models.User> Map(IEnumerable<Data.User> users)
        {
            return users.Select(Map);
        }
    }
}
