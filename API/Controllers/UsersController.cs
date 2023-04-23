using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IGenericRepos<User> _userRepos;
        public UsersController(IGenericRepos<User> userRepos)
        {
            _userRepos = userRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userRepos.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (id == 0) return BadRequest("Id must be different from 0!");
            var user = await _userRepos.GetById(id);
            if (user == null) return NotFound(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            var users = await _userRepos.GetAll();
            if (users.Any(u => u.Email == user.Email) || users.Any(u => u.Username == user.Username))
            {
                return BadRequest("Email or UserName is exists in database!");
            }
            user.UserId = 0;
            user.IsActived = true;
            user.IsOnline = false;
            if (user.RoleId != 1)
            {
                user.Loans = null;
            }
            await _userRepos.Create(user);
            return NoContent();
        }
        [HttpPut("{id}/{isOnline}")]
        public async Task<IActionResult> ChangeStatus(int id, bool isOnline)
        {
            var user = await _userRepos.GetById(id);
            user!.IsOnline = isOnline;
            return NoContent();
        }
        [HttpGet("CheckPassword")]
        public async Task<bool> CheckPassWord(int id, string password)
        {
            var user = await _userRepos.GetById(id);
            if (user!.VerifyPassword(password))
            {
                return true;
            }
            return false;
        }
        ActionResult NotFound(int id)
        {
            return NotFound($"User with id: {id} not found!");
        }
    }
}
