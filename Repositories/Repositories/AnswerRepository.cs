using Domain.Exeptions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.Default;
using Repositories.Repositories.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Repositories.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationContext context) : base(context)
        {

        }

        public IQueryable<Answer> GetAllByQuestion(int questionId)
        {
            return Db.Answers.Where(x => x.QuestionId == questionId && x.ArchivateDate == null);
        }

        public async Task<Answer> GetCorrectAnswerByQuestion(int questionId)
        {
            var answer = await Db.Answers.FirstOrDefaultAsync(x => x.QuestionId == questionId && x.isCorrect && x.ArchivateDate == null);

            if (answer == null)
                throw new NotFoundException();

            return answer;
        }

        public async Task<bool> IsCorrectAnswer(int id)
        {
            var answer = await Db.Answers.FirstOrDefaultAsync(x => x.Id == id && x.ArchivateDate == null);

            if(answer == null)
                throw new NotFoundException();

            return answer.isCorrect;
        }

        public async Task<int> CountCorrectAnswers(List<int> answerIds)
        {
            int count = 0;

            foreach (int answerId in answerIds.Where(id => id != 0))
            {
                if (await Db.Answers.AnyAsync(x => x.Id == answerId && x.isCorrect && x.ArchivateDate == null))
                    count++;
            }

            return count;
        }
    }
}
