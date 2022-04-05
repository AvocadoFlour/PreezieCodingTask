using Microsoft.AspNetCore.Mvc;
using PreezieCodingTask.Database;
using PreezieCodingTask.Entities.User;
using PreezieCodingTask.Helpers;
using PreezieCodingTask.Helpers.Users;

namespace PreezieCodingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private IUsersContext _usersContext;
        public UsersController(IUsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        // Note: Validation of the entity precedes the entry into the endpoint.
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                _usersContext.CreateUser(user);
                return Ok(user);
            }
            else
                return BadRequest("Invalid request");
        }

        [HttpPut]
        [Route("{id:long}")]
        public IActionResult UpdateUser(long id, UserUpdateDTO userUpdate)
        {
            _usersContext.UpdateUser(id, userUpdate);
            return Ok();
        }

        [HttpGet]
        public IActionResult ListUsers(RequestUsersDTO? listUsersDTO = null)
        {
            return Ok(_usersContext.ListUsers(listUsersDTO));
        }



    }
}
