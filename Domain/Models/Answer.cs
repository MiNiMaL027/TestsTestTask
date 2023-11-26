using Domain.Models.NotDbModels;

namespace Domain.Models
{
    public class Answer : BaseModel
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public bool isCorrect { get; set; }
    }
}
