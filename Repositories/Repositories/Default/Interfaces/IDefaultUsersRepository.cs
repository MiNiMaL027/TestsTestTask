using Domain.Models.NotDbModels;

namespace Repository.Default.Interfaces
{
    public interface IDefaultUsersRepository<T> : IDefaultRepository<T> where T : UserModel
    {
        public IQueryable<T> GetAllByUserId(string userId);
    }
}
