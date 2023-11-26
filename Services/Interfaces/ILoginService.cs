using Domain.Models;
using Domain.Models.NotDbModels;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Interfaces
{
    public interface ILoginService
    {
        Task<JwtSecurityToken> SignIn(LoginModel model);
        void SignOff();
        Task<User> Register(RegisterModel model);
    }
}
