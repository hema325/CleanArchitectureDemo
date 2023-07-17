using Application.Common.Interfaces;
using System.Security.Claims;

namespace WebApi.Services
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

        public string? Role => _httpContext.User.FindFirstValue(ClaimTypes.Role);

        public bool IsAuthenticated => _httpContext.User.Identity.IsAuthenticated;
    }
}
