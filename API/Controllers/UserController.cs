using API.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly GenericRepos _genericRepos;

        public UserController(GenericRepos genericRepos)
        {
            _genericRepos = genericRepos;
        }
    }
}
