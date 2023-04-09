using API.Data;
using API.Models.BookModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class BookIndexRepository : IBookIndexRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BookIndexRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookIndexM>> GetBooks()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookIndexM>>(books);
        }
    }
}
