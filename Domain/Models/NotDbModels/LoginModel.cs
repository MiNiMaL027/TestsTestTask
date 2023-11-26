using System.ComponentModel.DataAnnotations;

namespace Domain.Models.NotDbModels
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
