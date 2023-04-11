using API.Data;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Repos.Interfaces
{
    public class BookAuthorRepos : IBookAuthorRepos
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        public BookAuthorRepos(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AuthorModel>> GetListAuthor()
        {
            var books = await _context.Authors.ToListAsync();
            return _mapper.Map<List<AuthorModel>>(books);
        }
        public async Task<AuthorModel> GetAuthor(int id)
        {
            return _mapper.Map<AuthorModel>(await _context.FindAsync<Author>(id));
        }
    }
}
