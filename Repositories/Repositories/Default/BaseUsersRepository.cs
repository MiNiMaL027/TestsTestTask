using Domain.Models.NotDbModels;
using Repositories;
using Repositories.Repositories.Default;

namespace Repository.Default
{
    public abstract class BaseUsersRepository<T> : BaseRepository<T> where T : UserModel
    {
        public BaseUsersRepository(ApplicationContext context) : base(context)
        {

        }

        public IQueryable<T> GetAllByUserId(string userId)
        {
            return Db.Set<T>().Where(x => x.UserId == userId && x.ArchivateDate == null);
        }
    }
}
