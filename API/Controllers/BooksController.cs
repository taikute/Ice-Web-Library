using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Repos;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly GenericRepos _genericRepos;
        public BooksController(GenericRepos genericRepos)
        {
            _genericRepos = genericRepos;
        }
        [HttpGet("GetListBookIndex")]
        public async Task<ActionResult<List<BookIndexModel>>> GetListBookIndex()
        {
            return Ok(await _genericRepos.GetListAsync<BookIndexModel, Book>());
        }
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<BookModel>> GetBook(int id)
        {
            return Ok(await _genericRepos.GetByIdAsync<BookModel, Book>(id));
        }
        [HttpGet("GetBookEdit/{id}")]
        public async Task<ActionResult<BookEditModel>> GetBookEdit(int id)
        {
            return Ok(await _genericRepos.GetByIdAsync<BookEditModel, Book>(id));
        }
        [HttpPut]
        public async Task<IActionResult> PutBook(BookEditModel bookModel)
        {
            await _genericRepos.UpdateAsync<Book, BookEditModel>(bookModel.BookId, bookModel);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostBook(BookModel bookModel)
        {
            await _genericRepos.CreateAsync<Book, BookModel>(bookModel);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _genericRepos.DeleteAsync<Book>(id);
            return NoContent();
        }
    }
}
