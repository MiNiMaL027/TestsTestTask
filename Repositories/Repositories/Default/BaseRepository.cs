using Domain.Exeptions;
using Domain.Models.NotDbModels;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories.Default
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext Db;

        public BaseRepository(ApplicationContext context)
        {
            Db = context;
        }

        public async Task<int> Add(T item)
        {
            if (item == null)
                throw new ValidationException();

            Db.Set<T>().Add(item);

            await Db.SaveChangesAsync();

            return item.Id;
        }

        public IQueryable<T> GetAll()
        {
            return Db.Set<T>().Where(x => x.ArchivateDate == null);
        }

        public async Task<T> GetById(int id)
        {
            var item = await Db.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.ArchivateDate == null);

            if (item == null)
                throw new NotFoundException($"{id} - this id not found");

            return item;
        }

        public async Task<List<int>> Remove(List<int> ids)
        {
            var items = await Db.Set<T>().Where(x => ids.Contains(x.Id) && x.ArchivateDate == null).ToListAsync();

            if (items.Count == 0)
                throw new NotFoundException($"{ids} - any from this id not found");

            items.ForEach(x => x.ArchivateDate = DateTime.Now);

            await Db.SaveChangesAsync();

            return items.Select(x => x.Id).ToList();
        }

        public async Task<List<int>> RemoveFromDb(List<int> ids)
        {
            var items = await Db.Set<T>().Where(x => ids.Contains(x.Id) && x.ArchivateDate == null).ToListAsync();

            if (items.Count == 0)
                throw new NotFoundException($"{ids} - any from this id not found");

            Db.Set<T>().RemoveRange(items);

            await Db.SaveChangesAsync();

            return items.Select(x => x.Id).ToList();
        }

        public async Task<int> Update(T item)
        {
            if (item == null)
                throw new ValidationException();

            Db.Set<T>().Update(item);

            await Db.SaveChangesAsync();

            return item.Id;
        }
    }
}
