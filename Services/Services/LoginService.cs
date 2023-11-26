using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Domain.Exeptions;
using Domain.Models;
using Domain.Models.NotDbModels;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IConfiguration configuration;

        public LoginService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration _configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            configuration = _configuration;
        }

        public async Task<JwtSecurityToken> SignIn(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
             
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result == null)
                    throw new LoginException();

                if (result.RequiresTwoFactor)
                    throw new LoginException();

                if (result.IsLockedOut)
                    throw new LoginException();

                if (user.ArchivateDate != null)
                    throw new LoginException($"{user.UserName} - Deleted");

                if (result.Succeeded)
                {
                    var token = GetToken(authClaims);
                    return token;
                }
               
                throw new LoginException();
            }
            else
            {
                throw new LoginException();
            }
           
        }

        public async void SignOff()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<User> Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmedPassword)
                throw new LoginException();

            var user = new User
            {
                UserName = model.Name,
                Email = model.Email,   
            };

            if (await _userManager.FindByEmailAsync(model.Email) != null)
                throw new LoginException($"this email was registered.");

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {                         
                return user;
            }

            throw new LoginException();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

