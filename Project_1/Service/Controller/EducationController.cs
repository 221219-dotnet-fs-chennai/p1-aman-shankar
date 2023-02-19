using Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationLogic _educationLogic;
        public EducationController(IEducationLogic educationLogic)
        {
            _educationLogic = educationLogic;
        }
        [HttpGet("All_Education")]
        public ActionResult Get([FromQuery] string? Email) 
        {
            try
            {
                var educations = _educationLogic.GetEducations(Email);
                if(educations != null)
                {
                    return Ok(educations);
                }
                else
                {
                    return BadRequest("No Education Availabale");
                }
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add_Education")]
        public ActionResult Add([FromQuery] string? email, [FromBody] Education newEducation)
        {
            try
            {
                var newUserEducation = _educationLogic.AddEducation(email, newEducation);

                return CreatedAtAction("Add", newUserEducation);
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
        [HttpPut("Update_Education")]
        public ActionResult Update([FromQuery] string? email, [FromQuery] string? education, [FromBody] Education e)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(education))
                {
                    _educationLogic.UpdateEducation(email, education, e);
                    return Ok(e);
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
        [HttpDelete("Delete_Education")]
        public ActionResult Delete([FromQuery] string email, [FromQuery] string? education)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var rest = _educationLogic.RemoveEducation(email, education);
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
