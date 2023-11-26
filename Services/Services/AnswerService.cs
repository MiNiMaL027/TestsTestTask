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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<List<ViewAnswer>> GetAllByQuestion(int questinId)
        {
            var dbModels = _answerRepository.GetAllByQuestion(questinId);

            return await dbModels.ProjectTo<ViewAnswer>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<bool> isCorrectAnswer(int id)
        {
            return await _answerRepository.IsCorrectAnswer(id);
        }

        public async Task<int> Add(CreateAnswerModel model, int questionId)
        {
            if (model == null)
                throw new ValidationException();

            var dbModel = _mapper.Map<Answer>(model);

            dbModel.CreationDate = DateTime.Now;
            dbModel.QuestionId = questionId;

            return await _answerRepository.Add(dbModel);
        }

        public async Task<int> CountCorrectAnswers(List<int> answerIds)
        {
            return await _answerRepository.CountCorrectAnswers(answerIds);
        }
    }
}
