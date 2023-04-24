using API.Data;
using API.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        readonly IGenericRepos<Book> _loanRepos;
        public LoansController(IGenericRepos<Book> repository)
        {
            _loanRepos = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            return Ok(await _loanRepos.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            if (id == 0) return BadRequest("Id must be different from 0!");
            var loan = await _loanRepos.GetById(id);
            if (loan == null) return NotFound(id);
            return Ok(loan);
        }
    }
}
