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
    public class UserController : ControllerBase // controllerbase class has all methods and properties to handle HTTP Requests/responses
    {
        IUserLogic _logic;
        IMemoryCache _cache;
        public UserController(IUserLogic logic, IMemoryCache cache)
        {
            _logic = logic;
            _cache = cache;
        }
        // By default Aps.Net core supports text/plain as well as application/json
        /*[HttpGet]
        //[EnableCors("policy1")]
        public string GetString()
        {
            return "Hello world";
        }*/
        [HttpGet("All_Users")]
        public ActionResult Get()
        {
            try
            {
                var listOfUser = new List<User>();
                //TryGetValue(checks if cahce still exists and if it does "out listOfUsers" puts that that inside our variable)
                if (!_cache.TryGetValue("rest", out listOfUser))
                {
                    listOfUser = _logic.GetAllUsers().ToList();
                    _cache.Set("rest", listOfUser, new TimeSpan(0, 0, 30));
                }
                return Ok(listOfUser);
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
        [HttpGet("Email")]
        public ActionResult GetByEmail([FromQuery] string Email)
        {
            try
            {
                var search = _logic.GetUsersByUser_Email(Email);
                if (search != null)
                    return Ok(search);
                else
                    return NotFound($"User with ID {Email} not available, please try with different id");
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
/*        [HttpGet("Pincode")]
        public ActionResult GetByPincode([FromQuery] string Pincode)
        {
            try
            {
                var search = _logic.GetUsersByUser_Pincode(Pincode);
                if (search != null)
                    return Ok(search);
                else
                    return NotFound($"User with ID {Pincode} not available, please try with different id");
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
        [HttpGet("Gender")]
        public ActionResult GetByGender([FromQuery] string Gender)
        {
            try
            {
                var search = _logic.GetUsersByUser_Gender(Gender);
                if (search != null)
                    return Ok(search);
                else
                    return NotFound($"User with ID {Gender} not available, please try with different id");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }*/
        [HttpPost("Add_User")] // Trying to create a resource on the server
        public ActionResult Add([FromBody] User u)
        {
            try
            {
                var addedUser = _logic.AddUser(u);
                return CreatedAtAction("Add", addedUser); //201 -> Serialization of restaurant object
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
        [HttpPut("Update")]
        public ActionResult Update(string E_Mail, [FromBody] User u)
        {
            try
            {
                if (!string.IsNullOrEmpty(E_Mail))
                {
                    _logic.UpdateUser(E_Mail, u);
                    return Ok(u);
                }
                else
                    return BadRequest($"something wrong with {u.Email} input, please try again!");
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
        public ActionResult Delete([FromQuery]string Email)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var rest = _logic.RemoveUserByUser_Email(Email);
                    if (rest != null)
                        return Ok(rest);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Please add a valid user_id to be deleted");

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
