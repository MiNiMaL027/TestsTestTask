using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User: IdentityUser
    {
        public DateTime? ArchivateDate { get; set; }

        public virtual ICollection<UserTestResult> UserTestResults { get; set; } = new List<UserTestResult>();
    }
}
