using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class UserTestResult
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public bool isCompleted { get; set; }
    }
}
