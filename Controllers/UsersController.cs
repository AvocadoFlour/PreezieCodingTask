using Microsoft.AspNetCore.Mvc;
using PreezieCodingTask.Database;
using PreezieCodingTask.Entities;
using System.Text;

namespace PreezieCodingTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {

        private IUsersContext _usersContext;
        public UsersController(IUsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser(User user)
        {
            _usersContext.CreateUser(user.Email, user.Password, user.DisplayName);
            return Ok();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ListUsers()
        {
            return Ok(_usersContext.ListUsers().Count);
        }

    }
}
