using API.Models;

namespace API.Repos.Interfaces
{
    interface IBookAuthorRepos
    {
        Task<List<AuthorModel>> GetListAuthor();
        Task<AuthorModel> GetAuthor(int id);
        //Create, Update, Delete
    }
}
