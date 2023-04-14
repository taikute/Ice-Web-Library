using API.Data;
using API.Models;
using API.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        readonly GenericRepos _genericRepos;

        public PublishersController(GenericRepos genericRepos)
        {
            _genericRepos = genericRepos;
        }
        [HttpGet]
        public async Task<ActionResult<List<PublisherModel>>> GetPublishers()
        {
            return Ok(await _genericRepos.GetListAsync<PublisherModel, Publisher>());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherModel>> GetPublisher(int id)
        {
            return Ok(await _genericRepos.GetByIdAsync<PublisherModel, Publisher>(id));
        }
    }
}
