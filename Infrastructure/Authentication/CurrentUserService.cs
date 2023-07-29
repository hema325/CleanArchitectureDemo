using Application.Common.Interfaces.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly HttpContext _httpContext;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string? Id => _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string? UserName => _httpContext.User.FindFirstValue(ClaimTypes.Name);

        public bool IsAuthenticated => _httpContext.User.Identity.IsAuthenticated;
    }
}
