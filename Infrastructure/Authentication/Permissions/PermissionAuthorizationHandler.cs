using Application.Common.Interfaces.Caching;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Authentication.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;


namespace Infrastructure.Authentication.Permissions
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly ICacheService _cacheService;
        private readonly IUnitOfWork _unitOfWork; 

        public PermissionAuthorizationHandler(IServiceProvider serviceProvider)
        {
             serviceProvider = serviceProvider.CreateScope().ServiceProvider;

            _cacheService = serviceProvider.GetRequiredService<ICacheService>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated) 
                return;

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var key = $"UserPermissions-{userId}";

            var permissions = await _cacheService.GetAsync<IEnumerable<string>>(key);
            if (permissions == null)
            {
                permissions = (await _unitOfWork.Permissions.GetByUserId(userId)).Select(p => p.Name);

                await _cacheService.SetAsync(key, permissions);
            }

            if (permissions.Contains(requirement.Permission))
                context.Succeed(requirement);
        }
    }
}
