using API.Data;
using API.Repos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly AuthorRepos _authorRepos;
        public AuthorsController(AuthorRepos authorRepos)
        {
            _authorRepos = authorRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetListAuthor()
        {
            return Ok(await _authorRepos.GetAuthors());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            return Ok(await _authorRepos.GetAuthor(id));
        }
    }
}
