using API.Data;
using API.Repos.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class GenericRepos : IGenericRepos
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        //readonly ILogger _logger;
        public GenericRepos(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MainModel>> GetListAsync<MainModel, ItemModel>()
            where MainModel : class
            where ItemModel : class
        {
            var items = await _context.Set<ItemModel>().ToListAsync();
            return _mapper.Map<List<MainModel>>(items);
        }
        public async Task<MainModel> GetByIdAsync<MainModel, ItemModel>(int id)
            where MainModel : class
            where ItemModel : class
        {
            var item = await _context.Set<ItemModel>().FindAsync(id);
            return _mapper.Map<MainModel>(item);
        }
        public async Task CreateAsync<MainModel, ItemModel>(ItemModel item)
            where MainModel : class
            where ItemModel : class
        {
            var main = _mapper.Map<MainModel>(item);
            await _context.Set<MainModel>().AddAsync(main);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync<MainModel, ItemModel>(ItemModel item)
            where MainModel : class
            where ItemModel : class
        {
            try
            {
                var main = _mapper.Map<MainModel>(item);
                _context.Set<MainModel>().Update(main);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task DeleteAsync<MainModel>(int id) where MainModel : class
        {
                var item = await _context.Set<MainModel>().FindAsync(id);
                _context.Set<MainModel>().Remove(item!);
                await _context.SaveChangesAsync();
        }
    }
}
