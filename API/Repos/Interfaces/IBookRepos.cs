using API.Data;
using System.Collections;

namespace API.Repos.Interfaces
{
    interface IBookRepos
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(int id);
    }
}
