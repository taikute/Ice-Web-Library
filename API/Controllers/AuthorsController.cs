using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly IGenericRepos<Author> _authorRepos;
        public AuthorsController(IGenericRepos<Author> authorRepos)
        {
            _authorRepos = authorRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return Ok(await _authorRepos.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            return Ok(await _authorRepos.GetById(id));
        }
    }
}
