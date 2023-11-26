using Domain.Models.NotDbModels;

namespace Domain.Models
{
    public class Question : BaseModel
    {
        public int TestId { get; set; }
        public Test Test { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
