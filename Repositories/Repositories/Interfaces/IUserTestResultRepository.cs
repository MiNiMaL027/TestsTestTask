using Domain.Models;

namespace Repositories.Repositories.Interfaces
{
    public interface IUserTestResultRepository
    {
        Task<bool> CheckIfUserPassedTest(string userId, int testId);
        Task<bool> CheckIfUserCompletedTest(string userId, int testId);
        Task<bool> AddCompletedTest(UserTestResult userTestResult);
        Task<int> GetCountCompletedTest(string userId);
    }
}
