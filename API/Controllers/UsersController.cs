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
            if (users.Any(u => u.Email == user.Email))
                return BadRequest("Email is exists in database!");
            if (users.Any(u => u.Username == user.Username))
                return BadRequest("Username is exists in database!");
            user.Id = 0;
            user.IsLocked = false;
            if (user.RoleId != 1)
            {
                user.Loans = null;
            }
            await _userRepos.Create(user);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(User user)
        {
            // Lấy thông tin người dùng hiện tại từ cơ sở dữ liệu
            var existingUser = await _userRepos.GetById(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Cập nhật các trường khác của người dùng từ đối tượng user
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Username = user.Username;
            existingUser.CitizenIdentificationNumber = user.CitizenIdentificationNumber;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.LoanLeft = user.LoanLeft;

            // Lưu các thay đổi vào cơ sở dữ liệu
            await _userRepos.Update(existingUser);

            return NoContent();
        }

        [HttpGet("CheckPassword/{id}/{password}")]
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
