﻿using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Repos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly BookRepos _bookRepos;
        public BooksController(BookRepos bookRepos)
        {
            _bookRepos = bookRepos;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await _bookRepos.GetBooks());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (id == 0) return BadRequest("Id must be different from 0!");
            var book = await _bookRepos.GetBook(id);
            if (book == null) return BookNotFound(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> PostBook(Book book)
        {
            book.BookId = 0;
            book.Author = null;
            book.Category = null;
            book.Publisher = null;
            await _bookRepos.Create(book);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> PutBook(Book book)
        {
            int id = book.BookId;
            var existingBook = await _bookRepos.GetBook(id);
            if (existingBook == null) return BookNotFound(id);
            await _bookRepos.Update(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepos.GetBook(id);
            if (book == null) return BookNotFound(id);
            await _bookRepos.Delete(book);
            return NoContent();
        }
        ActionResult BookNotFound(int id)
        {
            return NotFound($"Book with id: {id} not found!");
        }
    }
}
