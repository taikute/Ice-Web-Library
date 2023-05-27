using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        readonly IGenericRepos<Status> _statusRepos;
        public StatusController(IGenericRepos<Status> repository)
        {
            _statusRepos = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _statusRepos.GetById(id));
        }
    }
}
