using Business_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Service.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase // controllerbase class has all methods and properties to handle HTTP Requests/responses
    {
        private readonly ISkillLogic _skillLogic;
        //private readonly IUserLogic _userLogic;
        public SkillController(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
            //_userLogic = userLogic;
        }

        [HttpGet("All_Skills/{Email}")]
        public ActionResult Get([FromRoute]string? Email)
        {
            try
            {
                var skills = _skillLogic.GetSkill(Email);
                if (skills != null)
                {
                    return Ok(skills);
                }
                else
                {
                    return BadRequest("No Skills Available");
                }
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

        [HttpPost("Add_Skill/{email}")] // Trying to create a resource on the server
        public ActionResult Add([FromRoute]string? email, [FromBody] Skills newSkill)
        {
            try
            {
                var newUserSkill = _skillLogic.AddSkill(email ,newSkill);

                return CreatedAtAction("Add", newUserSkill);
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

        [HttpPut("Update_Skill/{email}/{skill}")]
        public ActionResult Update([FromRoute]string? email, [FromRoute] string? skill , [FromBody] Skills s)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(skill))
                {
                    _skillLogic.UpdateSkill(email,skill,s);
                    return Ok(s);
                }
                else
                    return BadRequest($"something wrong with {email} input, please try again!");
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
        [HttpDelete("Delete_Skill/{email}/{skill}")]
        public ActionResult Delete([FromRoute]string email , [FromRoute] string? skill)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var rest = _skillLogic.RemoveSkill(email , skill);
                    if (rest != null)
                        return Ok(rest);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please add a valid Email to be deleted");

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

    }
}
