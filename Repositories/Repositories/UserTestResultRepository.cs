using Domain.Exeptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class UserTestResultRepository : IUserTestResultRepository
    {
        public ApplicationContext Db { get; set; }
        public UserTestResultRepository(ApplicationContext db)
        {
            Db = db;
        }

        public async Task<bool> CheckIfUserPassedTest(string userId, int testId)
        {
            return await Db.UserTestResults
                .AnyAsync(utr => utr.UserId == userId && utr.TestId == testId);
        }

        public async Task<bool> CheckIfUserCompletedTest(string userId, int testId)
        {
             var userTestResult = await Db.UserTestResults
                .FirstOrDefaultAsync(utr => utr.UserId == userId && utr.TestId == testId);

            if(userTestResult == null)
                throw new NotFoundException();

            return userTestResult.isCompleted;
        }

        public async Task<bool> AddCompletedTest(UserTestResult userTestResult)
        {
            var user = await Db.Users.FirstOrDefaultAsync(x => x.Id == userTestResult.UserId && x.ArchivateDate == null);

            if (user == null)
                throw new NotFoundException();

            user.UserTestResults.Add(userTestResult);

            await Db.SaveChangesAsync();

            return true;
        }

        public async Task<int> GetCountCompletedTest(string userId)
        {
            return await Db.UserTestResults.CountAsync(x => x.UserId == userId);
        }
    }
}
