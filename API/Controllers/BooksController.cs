using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using AutoMapper;
using API.Repos;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly BookRepo _bookRepo;
        readonly DataContext _context;
        public BooksController(DataContext context, BookRepo bookRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
        }

        [HttpGet("GetListBookIndex")]
        public async Task<ActionResult<List<BookIndexModel>>> GetListBookIndex()
        {
            return Ok(await _bookRepo.GetListBookIndexModel());
        }

        [HttpGet("GetBookEditModel/{id}")]
        public async Task<ActionResult<BookEditModel>> GetBookEditModel(int id)
        {
            return Ok(await _bookRepo.GetBookEditModel(id));
        }

        [HttpPut]
        public async Task<IActionResult> PutBook(BookEditModel bookEditModel)
        {
            await _bookRepo.UpdateBookEditModel(bookEditModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'DataContext.Books'  is null.");
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.ID }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
