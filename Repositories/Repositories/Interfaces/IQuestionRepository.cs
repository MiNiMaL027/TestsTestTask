using Domain.Models;
using Repository.Default.Interfaces;

namespace Repositories.Repositories.Interfaces
{
    public interface IQuestionRepository : IDefaultRepository<Question>
    {
        Task<Question> GetByTestId(int TestId, int number);
        IQueryable<Question> GetAllByTestId(int testId);
    }
}
