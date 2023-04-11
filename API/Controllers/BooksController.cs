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
        readonly BookRepos _bookRepos;
        readonly DataContext _context;
        public BooksController(DataContext context, BookRepos bookRepos)
        {
            _context = context;
            _bookRepos = bookRepos;
        }

        [HttpGet("GetListBookIndex")]
        public async Task<ActionResult<List<BookIndexModel>>> GetListBookIndex()
        {
            return Ok(await _bookRepos.GetListBookIndex());
        }

        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<BookModel>> GetBook(int id)
        {
            return Ok(await _bookRepos.GetBook(id));
        }

        [HttpGet("GetBookDetail/{id}")]
        public async Task<ActionResult<BookDetailModel>> GetBookDetail(int id)
        {
            return Ok(await _bookRepos.GetBookDetail(id));
        }

        [HttpPut]
        public async Task<IActionResult> PutBook(BookModel bookModel)
        {
            await _bookRepos.UpdateBook(bookModel);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostBook(BookModel bookModel)
        {
            await _bookRepos.CreateBook(bookModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepos.DeleteBook(id);
            return NoContent();
        }
    }
}
