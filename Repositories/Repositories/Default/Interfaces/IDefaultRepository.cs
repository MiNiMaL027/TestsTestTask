using Domain.Models.NotDbModels;

namespace Repository.Default.Interfaces
{
    public interface IDefaultRepository<T> where T : BaseModel
    {
        public Task<int> Add(T item);
        public IQueryable<T> GetAll();
        public Task<T> GetById(int id);
        public Task<List<int>> Remove(List<int> ids);
        public Task<List<int>> RemoveFromDb(List<int> ids);
        public Task<int> Update(T item);
    }
}
