using System.ComponentModel.DataAnnotations;

namespace Domain.Models.NotDbModels
{
    public class RegisterModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }
    }
}
