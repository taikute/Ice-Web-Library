using API.Data;
using API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class AuthorRepos : IAuthorRepos
    {
        readonly DataContext _context;
        readonly ILogger _logger;
        public AuthorRepos(DataContext context, ILogger<BookRepos> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }
        public async Task<Author?> GetAuthor(int id)
        {
            return await _context.Authors.FindAsync(id);
        }
        public Task Create(Author author)
        {
            throw new NotImplementedException();
        }
        public Task Update(Author author)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task ContextSaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Author saved to database!");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error while saving author to database!");
            }
        }
    }
}
