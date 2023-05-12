using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Repos.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IGenericRepos<Book> _bookRepos;
        public BooksController(IGenericRepos<Book> repository)
        {
            _bookRepos = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await _bookRepos.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (id == 0) return BadRequest("Id must be different from 0!");
            var book = await _bookRepos.GetById(id);
            if (book == null) return NotFound(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> PostBook(Book book)
        {
            book.Id = 0;
            book.Author = null;
            book.Category = null;
            book.Publisher = null;
            await _bookRepos.Create(book);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> PutBook(Book book)
        {
            await _bookRepos.Update(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepos.GetById(id);
            if (book == null) return NotFound(id);
            await _bookRepos.Delete(book);
            return NoContent();
        }
        ActionResult NotFound(int id)
        {
            return NotFound($"Book with id: {id} not found!");
        }
    }
}
