using Domain.CreateModels;
using Domain.ViewModel;

namespace Services.Interfaces
{
    public interface IAnswerService
    {
        Task<List<ViewAnswer>> GetAllByQuestion(int questinId);
        Task<bool> isCorrectAnswer(int id);
        Task<int> Add(CreateAnswerModel model, int questionId);
        Task<int> CountCorrectAnswers(List<int> answerIds);
    }
}
