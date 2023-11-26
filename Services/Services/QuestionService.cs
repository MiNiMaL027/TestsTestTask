using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.CreateModels;
using Domain.Exeptions;
using Domain.Models;
using Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<ViewQuestion> GetByTestIdAndNumber(int testId, int number)
        {
            var dbModel = await _questionRepository.GetByTestId(testId, number);

            return _mapper.Map<ViewQuestion>(dbModel);
        }

        public async Task<List<ViewQuestion>> GetAllByTestId(int testId)
        {
            var DbMoedels = _questionRepository.GetAllByTestId(testId);

            return await DbMoedels.ProjectTo<ViewQuestion>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<int> Add(CreateQuestionModel model, int testId)
        {
            if (model == null)
                throw new ValidationException();

            var dbModel = _mapper.Map<Question>(model);

            dbModel.CreationDate = DateTime.Now;
            dbModel.TestId = testId;

            return await _questionRepository.Add(dbModel);
        }
    }
}
