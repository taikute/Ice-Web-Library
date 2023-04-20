using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class BookRepos
    {
        readonly DataContext _context;
        readonly ILogger _logger;
        public BookRepos(DataContext context, ILogger<BookRepos> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book?> GetBook(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await ContextSaveChangeAsync();
        }
        public async Task Update(Book book)
        {
            _context.Update(book);
            await ContextSaveChangeAsync();
        }
        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await ContextSaveChangeAsync();
        }
        async Task ContextSaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Book saved to database!");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error while saving book to database!");
            }
        }
    }
}
