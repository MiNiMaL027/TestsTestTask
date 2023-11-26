using Domain.Models;
using Repository.Default.Interfaces;

namespace Repositories.Repositories.Interfaces
{
    public interface IAnswerRepository : IDefaultRepository<Answer>
    {
        IQueryable<Answer> GetAllByQuestion(int questionId);
        Task<Answer> GetCorrectAnswerByQuestion(int questionId);
        Task<bool> IsCorrectAnswer(int id);
        Task<int> CountCorrectAnswers(List<int> answerIds);
    }
}
