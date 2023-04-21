using API.Data;
using API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class GenericRepos<T> : IGenericRepos<T> where T : class
    {
        readonly DataContext _context;
        readonly ILogger<GenericRepos<T>> _logger;
        readonly string _name;
        public GenericRepos(DataContext context, ILogger<GenericRepos<T>> logger)
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
                _logger.LogInformation($"{_name}: Save changes successfull!");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"{_name}: Error while save change to database!");
            }
        }
    }
}
