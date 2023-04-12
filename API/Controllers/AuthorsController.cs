using API.Data;
using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly GenericRepos _genericRepos;

        public AuthorsController(GenericRepos genericRepos)
        {
            _genericRepos = genericRepos;
        }
        [HttpGet]
        public async Task<ActionResult<List<AuthorModel>>> GetListAuthor()
        {
            return Ok(await _genericRepos.GetListAsync<AuthorModel, Author>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorModel>> GetAuthor(int id)
        {
            return Ok(await _genericRepos.GetByIdAsync<AuthorModel, Author>(id));
        }
    }
}
