using API.Data;

namespace API.Repos.Interfaces
{
    interface IAuthorRepos
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthor(int id);
        Task Create(Author author);
        Task Update(Author author);
        Task Delete(int id);
    }
}
