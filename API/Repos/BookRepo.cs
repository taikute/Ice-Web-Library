using API.Data;
using API.Models;
using API.Repos.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class BookRepo : IBookRepo
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        public BookRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookIndexModel>> GetListBookIndexModel()
        {
            return await _context.Books.ProjectTo<BookIndexModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<BookEditModel> GetBookEditModel(int id)
        {
            return _mapper.Map<BookEditModel>(await _context.FindAsync<Book>(id));
        }

        public async Task UpdateBookEditModel(BookEditModel bookEditModel)
        {
            var book = await _context.Books.FindAsync(bookEditModel.ID);
            _mapper.Map(bookEditModel, book);
            await _context.SaveChangesAsync();
        }
    }
}
