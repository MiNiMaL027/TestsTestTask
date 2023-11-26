using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.CreateModels;
using Domain.Exeptions;
using Domain.Models;
using Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.Interfaces;
using Repository.Default.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class TestService : ITestService
    {
        private readonly IDefaultUsersRepository<Test> _testRepository;
        private readonly IUserTestResultRepository _userTestResultRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizeService<Test> _authorizeService;

        public TestService(IDefaultUsersRepository<Test> testRepository, IMapper mapper, IUserTestResultRepository userTestResultRepository, IAuthorizeService<Test> authorizeService)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _authorizeService = authorizeService;
            _userTestResultRepository = userTestResultRepository;
        }

        public async Task<List<ViewTest>> GetAllTest()
        {
            var DbModels = _testRepository.GetAll();

            return await DbModels.ProjectTo<ViewTest>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<int> Add(CreateTestModel model)
        {
            if (model == null)
                throw new ValidationException();

            var dbModel = _mapper.Map<Test>(model);

            dbModel.CreationDate = DateTime.Now;
            dbModel.UserId = _authorizeService.UserId;

            return await _testRepository.Add(dbModel);
        }

        public async Task<bool> CompleteTest(int testId, int correctAnswerCount)
        {
            var test = await _testRepository.GetById(testId);

            var userTestResult = new UserTestResult()
            {
                TestId = testId,
                UserId = _authorizeService.UserId,
                isCompleted = test.RequiredCorrectAnswers <= correctAnswerCount
            };

            await _userTestResultRepository.AddCompletedTest(userTestResult);

            return test.RequiredCorrectAnswers <= correctAnswerCount;
        }

        public async Task<bool> isTestPassed(int testId)
        {
            return await _userTestResultRepository.CheckIfUserPassedTest(_authorizeService.UserId, testId);
        }

        public async Task<bool> isTestCompleted(int testId)
        {
            return await _userTestResultRepository.CheckIfUserCompletedTest(_authorizeService.UserId, testId);
        }
    }
}
