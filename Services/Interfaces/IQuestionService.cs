using Domain.CreateModels;
using Domain.ViewModel;

namespace Services.Interfaces
{
    public interface IQuestionService
    {
        Task<int> Add(CreateQuestionModel model, int testId);
        Task<List<ViewQuestion>> GetAllByTestId(int testId);
        Task<ViewQuestion> GetByTestIdAndNumber(int testId, int number);
    }
}
