using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        readonly IGenericRepos<Publisher> _publisherRepos;
        public PublishersController(IGenericRepos<Publisher> publisherRepos)
        {
            _publisherRepos = publisherRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            return Ok(await _publisherRepos.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
        {
            return Ok(await _publisherRepos.GetById(id));
        }
    }
}
