using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly IGenericRepos<Category> _categoryRepos;
        public CategoriesController(IGenericRepos<Category> categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await _categoryRepos.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return Ok(await _categoryRepos.GetById(id));
        }
    }
}
