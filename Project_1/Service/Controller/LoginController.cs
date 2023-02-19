using Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserLogin_Logic _userLogic;
        Validation _valid;
        public LoginController(IUserLogin_Logic userLogic, Validation valid)
        {
            _userLogic = userLogic;
            _valid = valid;
        }
        [HttpGet("Login")]
        public ActionResult Login(string Email, string Password , string User_Id)
        {
            if (!_valid.CheckUserExists(Email, Password , User_Id))
            {
                return Unauthorized("No Details Found");
            }
            else
            {
                return Ok("User Found");
            }
        }
    }
}
