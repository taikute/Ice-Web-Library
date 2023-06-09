﻿using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstancesController : ControllerBase
    {
        readonly IGenericRepos<Instance> _instanceRepos;
        public InstancesController(IGenericRepos<Instance> instanceRepos)
        {
            _instanceRepos = instanceRepos;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instance>>> GetInstances()
        {
            return Ok(await _instanceRepos.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Instance>> GetInstance(int id)
        {
            return Ok(await _instanceRepos.GetById(id));
        }
        [HttpPut]
        public async Task<IActionResult> PutInstance(Instance instance)
        {
            await _instanceRepos.Update(instance);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostInstance(Instance instance)
        {
            await _instanceRepos.Create(instance);
            return NoContent();
        }
    }
}
