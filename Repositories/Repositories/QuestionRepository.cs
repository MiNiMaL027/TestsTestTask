using Domain.Exeptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.Default;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<Question> GetByTestId(int testId, int number)
        {
            var question = await Db.Questions
            .Where(q => q.TestId == testId && q.ArchivateDate == null)
            .OrderBy(q => q.Id)
            .Skip(number - 1)     // -1 тому що номери зазвичай починаються з 1, але індекси в C# з 0
            .Take(1)
            .SingleOrDefaultAsync();

            if (question == null)
                throw new NotFoundException();

            return question;
        }

        public IQueryable<Question> GetAllByTestId(int testId)
        {
            return Db.Questions.Where(x => x.TestId == testId && x.ArchivateDate == null);
        }
    }
}
