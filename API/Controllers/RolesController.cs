﻿using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        readonly IGenericRepos<Role> _roleRepos;
        public RolesController(IGenericRepos<Role> roleRepos)
        {
            _roleRepos = roleRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Index()
        {
            return Ok(await _roleRepos.GetAll());
        }
    }
}
