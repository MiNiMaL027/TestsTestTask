namespace Domain.Models.NotDbModels
{
    public class UserModel : BaseModel
    {
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
