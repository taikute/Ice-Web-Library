using API.Models.BookModels;

namespace API.Repos
{
    public interface IBookIndexRepository
    {
        public Task<List<BookIndexM>> GetBooks();
    }
}
