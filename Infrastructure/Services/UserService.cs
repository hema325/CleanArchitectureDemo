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
    public class UserService : IUser
    {
        private readonly HttpContext _httpContext;

        public UserService(IHttpContextAccessor accessor)
        {
            _httpContext = accessor.HttpContext;
        }

        public string? Id => _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public bool IsAuthenticated => _httpContext.User.Identity.IsAuthenticated;
    }
}
