using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly HttpContext _httpContext;

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _httpContext = accessor.HttpContext;
        }

        public string? Id => _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public string? UserName => _httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        public string? Role => _httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        public bool IsAuthenticated => _httpContext.User.Identity.IsAuthenticated;

    }
}
