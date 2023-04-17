using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class BookRepos
    {
        readonly DataContext _context;
        readonly ILogger _logger;
        public BookRepos(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            if (books == null)
            {
                return Enumerable.Empty<Book>();
            }
            return books;
        }
        public async Task<Book?> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                BookNotFound(id);
                return null;
            }
            return book;
        }
        public async Task Create(Book book)
        {
            int id = book.BookId;
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook != null) BookAlreadyExists(id);
            else
            {
                await _context.Books.AddAsync(book);
                await ContextSaveChangeAsync();
            }
        }
        public async Task Update(Book book)
        {
            int id = book.BookId;
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null) BookNotFound(id);
            else
            {
                _context.Update(book);
                await ContextSaveChangeAsync();
            }
        }
        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await ContextSaveChangeAsync();
            }
            else BookNotFound(id);
        }

        void BookAlreadyExists(int id)
        {
            _logger.LogError($"Book with ID: {id} already exists");
        }
        void BookNotFound(int id)
        {
            _logger.LogError($"Book with ID: {id} was not found");
        }
        async Task ContextSaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error while saving book to database!");
            }
        }
    }
}
