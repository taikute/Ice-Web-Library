﻿using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        readonly IGenericRepos<Loan> _loanRepos;
        readonly IGenericRepos<Instance> _instanceRepos;
        public LoansController(IGenericRepos<Loan> repository, IGenericRepos<Instance> instanceRepos)
        {
            _loanRepos = repository;
            _instanceRepos = instanceRepos;
        }

        [HttpGet("{userId?}")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans(int? userId)
        {
            var loans = await _loanRepos.GetAll();
            loans = loans.Where(l => l.UserId == userId);
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            var loan = await _loanRepos.GetById(id);
            return Ok(loan);
        }
        [HttpPost]
        public async Task<IActionResult> PostLoan(Loan loan)
        {
            await _loanRepos.Create(loan);
            return NoContent();
        }
    }
}
