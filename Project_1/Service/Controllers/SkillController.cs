using Business_Logic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Models;

namespace Service.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase // controllerbase class has all methods and properties to handle HTTP Requests/responses
    {
        private readonly ISkillLogic _skillLogic;
        private readonly IUserLogic _userLogic;
        public SkillController(ISkillLogic skillLogic, IUserLogic userLogic)
        {
            _skillLogic = skillLogic;
            _userLogic = userLogic;
        }

        [HttpGet("All_Skills")]
        public ActionResult Get(string email)
        {
            var skillSearchedById = _userLogic.GetUsersByUser_Email(email);
            return Ok(_skillLogic.GetSkills(skillSearchedById));
        }

        [HttpPost("Add_Skill")] // Trying to create a resource on the server
        public ActionResult Add(string email, [FromBody] Skills newSkill)
        {
            try
            {
                var userSearchedByEmail = _userLogic.GetUsersByUser_Email(email);

                return Created($"/api/User/{email}/Skill",
                    _skillLogic.AddSkills(
                            userSearchedByEmail, newSkill
                            ));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
/*
        [HttpPut("Update")]
        public ActionResult Update(string s_id, [FromBody] Skills s)
        {
            try
            {
                if (!string.IsNullOrEmpty(s_id))
                {
                    _skillLogic.UpdateSkill(s_id, s);
                    return Ok(s);
                }
                else
                    return BadRequest($"something wrong with {s.s_id} input, please try again!");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public ActionResult Delete(string s_id)
        {
            try
            {
                if (!string.IsNullOrEmpty(s_id))
                {
                    var rest = _skillLogic.RemoveSkillByS_Id(s_id);
                    if (rest != null)
                        return Ok(rest);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please add a valid s_id to be deleted");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

    }
}
