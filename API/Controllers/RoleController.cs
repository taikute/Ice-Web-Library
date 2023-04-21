using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IGenericRepos<Role> _roleRepos;

        public RoleController(IGenericRepos<Role> roleRepos)
        {
            _roleRepos = roleRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Index()
        {
            return Ok();
        }
    }
}
