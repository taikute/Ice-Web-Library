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
        [HttpGet("GetListBook")]
        public async Task<ActionResult<List<BookModel>>> GetListBook()
        {
            return Ok(await _genericRepos.GetListAsync<BookModel, Book>());
        }
        [HttpGet("GetListBookIndex")]
        public async Task<ActionResult<List<BookIndexModel>>> GetListBookIndex()
        {
            return Ok(await _genericRepos.GetListAsync<BookIndexModel, Book>());
        }
        [HttpGet("GetListBookSearch")]
        public async Task<ActionResult<List<BookSearchModel>>> GetListBookSearch()
        {
            return Ok(await _genericRepos.GetListAsync<BookSearchModel, Book>());
        }
        [HttpGet("GetListBookBase")]
        public async Task<ActionResult<List<BookBaseModel>>> GetListBookBase()
        {
            return Ok(await _genericRepos.GetListAsync<BookBaseModel, Book>());
        }
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<BookModel>> GetBook(int id)
        {
            return Ok(await _genericRepos.GetByIdAsync<BookModel, Book>(id));
        }
        [HttpGet("GetBookBase/{id}")]
        public async Task<ActionResult<BookBaseModel>> GetBookBase(int id)
        {
            return Ok(await _genericRepos.GetByIdAsync<BookBaseModel, Book>(id));
        }
        [HttpPut]
        public async Task<IActionResult> PutBook(BookBaseModel bookModel)
        {
            await _genericRepos.UpdateAsync<Book, BookBaseModel>(bookModel.BookId, bookModel);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostBook(BookBaseModel bookModel)
        {
            await _genericRepos.CreateAsync<Book, BookBaseModel>(bookModel);
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
