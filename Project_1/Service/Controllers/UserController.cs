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
        // [EnableCors("policy2")]
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
        public ActionResult Update(string user_id, [FromBody] User u)
        {
            try
            {
                if (!string.IsNullOrEmpty(user_id))
                {
                    _logic.UpdateUser(user_id, u);
                    return Ok(u);
                }
                else
                    return BadRequest($"something wrong with {u.user_id} input, please try again!");
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
        public ActionResult Delete(string user_id)
        {
            try
            {
                if (!string.IsNullOrEmpty(user_id))
                {
                    var rest = _logic.RemoveUserByUser_Id(user_id);
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
