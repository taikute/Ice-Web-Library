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
        public UsersController(IGenericRepos<User> userRepos, DataContext context)
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
        ActionResult NotFound(int id)
        {
            return NotFound($"User with id: {id} not found!");
        }
    }
}
