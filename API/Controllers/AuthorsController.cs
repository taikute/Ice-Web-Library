using API.Data;
using API.Models;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly BookAuthorRepos _bookAuthorRepos;
        readonly DataContext _dataContext;

        public AuthorsController(BookAuthorRepos bookAuthorRepos, DataContext dataContext)
        {
            _bookAuthorRepos = bookAuthorRepos;
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<AuthorModel>>> GetListAuthor()
        {
            return Ok(await _bookAuthorRepos.GetListAuthor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorModel>> GetAuthor(int id)
        {
            return Ok(await _bookAuthorRepos.GetAuthor(id));
        }
    }
}
