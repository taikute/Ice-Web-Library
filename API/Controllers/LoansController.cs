using API.Data;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            var loans = await _loanRepos.GetAll();
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
        [HttpPut]
        public async Task<IActionResult> PutLoan(Loan loan)
        {
            await _loanRepos.Update(loan);
            return NoContent();
        }
    }
}
