using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IGenericRepos<User> _userRepos;
        readonly DataContext _context;
        public UserController(IGenericRepos<User> userRepos, DataContext context)
        {
            _userRepos = userRepos;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return Ok(users);
        }
    }
}
