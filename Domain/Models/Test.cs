using Domain.Models.NotDbModels;

namespace Domain.Models
{
    public class Test : UserModel
    {
        public string Description { get; set; }
        public int RequiredCorrectAnswers { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<UserTestResult> UserTestResult { get; set; } = new List<UserTestResult>();
    }
}
