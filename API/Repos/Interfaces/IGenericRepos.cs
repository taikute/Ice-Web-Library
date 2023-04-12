namespace API.Repos.Interfaces
{
    interface IGenericRepos
    {
        Task<List<MainModel>> GetListAsync<MainModel, ItemModel>()
            where MainModel : class
            where ItemModel : class;
        Task<MainModel> GetByIdAsync<MainModel, ItemModel>(int id)
            where MainModel : class
            where ItemModel : class;
        Task CreateAsync<MainModel, ItemModel>(ItemModel item)
            where MainModel : class
            where ItemModel : class;
        Task UpdateAsync<MainModel, ItemModel>(ItemModel item)
            where MainModel : class
            where ItemModel : class;
        Task DeleteAsync<MainModel>(int id) where MainModel : class;
    }
}
