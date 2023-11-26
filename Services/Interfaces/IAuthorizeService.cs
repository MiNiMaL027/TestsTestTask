using Domain.Models.NotDbModels;

namespace Services.Interfaces
{
    public interface IAuthorizeService<T> where T : UserModel
    {
        public string UserId { get; }
        public Task AuthorizeUser(int id);
    }
}
