using API.Data;
using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly GenericRepos _genericRepos;

        public CategoriesController(GenericRepos genericRepos)
        {
            _genericRepos = genericRepos;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetCategories()
        {
            return Ok(await _genericRepos.GetListAsync<CategoryModel, Category>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategory(int id)
        {
            return Ok(await _genericRepos.GetByIdAsync<CategoryModel, Category>(id));
        }
    }
}
