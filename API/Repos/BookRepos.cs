using API.Data;
using API.Models;
using API.Repos.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class BookRepos : IBookRepos
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        public BookRepos(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookIndexModel>> GetListBookIndex()
        {
            return await _context.Books.ProjectTo<BookIndexModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<BookModel> GetBook(int id)
        {
            return _mapper.Map<BookModel>(await _context.FindAsync<Book>(id));
        }

        public async Task<BookDetailModel> GetBookDetail(int id)
        {
            return _mapper.Map<BookDetailModel>(await _context.FindAsync<Book>(id));
        }

        public async Task UpdateBook(BookModel bookModel)
        {
            var book = await _context.Books.FindAsync(bookModel.BookId);
            _mapper.Map(bookModel, book);
            await _context.SaveChangesAsync();
        }
        public async Task CreateBook(BookModel bookModel)
        {
            var book = _mapper.Map<Book>(bookModel);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book!);
            await _context.SaveChangesAsync();

        }
    }
}
