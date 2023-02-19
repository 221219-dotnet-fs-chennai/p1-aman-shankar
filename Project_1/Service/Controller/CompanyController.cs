using Business_Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyLogic _companyLogic;
        public CompanyController(ICompanyLogic companyLogic)
        {
            _companyLogic = companyLogic;
        }
        [HttpGet("All_Companies")]
        public ActionResult Get([FromQuery] string? Email)
        {
            try
            {
                var companies = _companyLogic.GetCompanies(Email);
                if (companies != null)
                {
                    return Ok(companies);
                }
                else
                {
                    return BadRequest("No Companies Available");
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
        [HttpPost("Add_Company")]
        public ActionResult Add([FromQuery] string? email, [FromBody] Company newCompany)
        {
            try
            {
                var newUserCompany = _companyLogic.AddCompany(email, newCompany);

                return CreatedAtAction("Add", newUserCompany);
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
        [HttpPut("Update_Company")]
        public ActionResult Update([FromQuery] string? email, [FromQuery] string? company, [FromBody] Company c)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(company))
                {
                    _companyLogic.UpdateCompany(email, company, c);
                    return Ok(c);
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
        [HttpDelete("Delete_Company")]
        public ActionResult Delete([FromQuery] string email, [FromQuery] string? company)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var rest = _companyLogic.RemoveCompany(email, company);
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
