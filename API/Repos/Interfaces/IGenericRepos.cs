namespace API.Repos.Interfaces
{
    public interface IGenericRepos<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Create(T model);
        Task Update(T model);
        Task Delete(T model);
    }
}
