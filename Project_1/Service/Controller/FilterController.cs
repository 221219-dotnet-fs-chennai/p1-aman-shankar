/*using Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        ILogic logic;
        public FilterController(ILogic _logic)
        {
            logic = _logic;
        }
        [HttpGet("ByGender/{Gender}")]
        public ActionResult GetUserByGender([FromRoute] string Gender)
        {
            try
            {
                var x = logic.GetAllUser();
                if (x != null)
                {
                    return Ok(x);
                }
                else
                {
                    return NoContent();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByPincode/{Pincode}")]
        public ActionResult GetUserByPincode([FromRoute] string Pincode)
        {
            try
            {
                var x = logic.GetAllUser();
                if (x != null)
                {
                    return Ok(x);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}*/
