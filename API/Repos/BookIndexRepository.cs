using API.Data;
using API.Models.BookModels;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace API.Repos
{
    public class BookIndexRepository : IBookIndexRepository
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        public BookIndexRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookIndexM>> GetBookIndex()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookIndexM>>(books);
        }
    }
}
