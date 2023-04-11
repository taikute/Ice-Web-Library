using API.Models;

namespace API.Repos.Interfaces
{
    public interface IBookRepos
    {
        Task<List<BookIndexModel>> GetListBookIndex();
        Task<BookModel> GetBook(int id);
        Task<BookDetailModel> GetBookDetail(int id);
        Task CreateBook(BookModel bookModel);
        Task UpdateBook(BookModel bookModel);
        Task DeleteBook(int id);
    }
}
