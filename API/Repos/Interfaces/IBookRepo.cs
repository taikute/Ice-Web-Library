using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Repos.Interfaces
{
    public interface IBookRepo
    {
        public Task<List<BookIndexModel>> GetListBookIndexModel();
        public Task<BookEditModel> GetBookEditModel(int id);
        public Task UpdateBookEditModel(BookEditModel bookEditModel);
    }
}
