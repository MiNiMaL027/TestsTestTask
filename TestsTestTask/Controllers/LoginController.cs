using Domain.Models.NotDbModels;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService service)
        {
            _loginService = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var token = await _loginService.SignIn(loginModel);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            return Ok(await _loginService.Register(registerModel));
        }

        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            _loginService.SignOff();

            return Ok();
        }
    }
}
