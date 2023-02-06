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
        [HttpGet("all")]
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
    }
}
