using API.Data;
using API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly DataContext _context;
        readonly ILogger _logger;
        readonly string _name;
        public GenericRepository(DataContext context, ILogger<BookRepos> logger)
        {
            _context = context;
            _logger = logger;
            _name = typeof(T).Name;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Create(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await ContextSaveChangeAsync();
        }
        public async Task Update(T model)
        {
            _context.Set<T>().Update(model);
            await ContextSaveChangeAsync();
        }
        public async Task Delete(T model)
        {
            _context.Set<T>().Remove(model);
            await ContextSaveChangeAsync();
        }

        async Task ContextSaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation($"{_name} saved to database!");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Error while saving {_name} to database!");
            }
        }
    }
}
