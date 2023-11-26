using Domain.CreateModels;
using Domain.ViewModel;

namespace Services.Interfaces
{
    public interface ITestService
    {
        Task<List<ViewTest>> GetAllTest();
        Task<int> Add(CreateTestModel model);
        Task<bool> CompleteTest(int testId, int correctAnswerCount);
        Task<bool> isTestPassed(int testId);
        Task<bool> isTestCompleted(int testId);
    }
}
