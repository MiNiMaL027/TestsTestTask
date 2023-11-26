using Domain.Exeptions;
using Domain.Models.NotDbModels;
using Microsoft.AspNetCore.Http;
using Repository.Default.Interfaces;
using Services.Interfaces;
using System.Security.Claims;

namespace Services.Services
{
    public class AuthorizeService<T> : IAuthorizeService<T> where T : UserModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDefaultUsersRepository<T> _repository;

        public string UserId { 
            get
            {
                var user = _httpContextAccessor.HttpContext.User;

                if(user.Identity.IsAuthenticated)
                {
                    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                    return userId;
                }

                throw new UnautorizeException("No Accessed");
            }
        }

        public AuthorizeService(IHttpContextAccessor http, IDefaultUsersRepository<T> repository)
        {
            _httpContextAccessor = http;
            _repository = repository;
        }

        public async Task AuthorizeUser(int id)
        {
            var item = await _repository.GetById(id);

            if (item == null)
                throw new NotFoundException();

            if (item.UserId != _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                throw new UnautorizeException("No Accessed");
        }
    }
}
