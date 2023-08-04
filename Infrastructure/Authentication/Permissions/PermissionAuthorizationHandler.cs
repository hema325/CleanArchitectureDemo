using Application.Common.Interfaces.Repositories;
using Infrastructure.Authentication.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.Permissions
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        /* every request we need to access the database which make it slow
private readonly IUnitOfWork _unitOfWork;
public PermissionAuthorizationHandler(IServiceProvider serviceProvider)
{
   _unitOfWork = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();
}
protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
{
   var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

   if (userId == null)
       return;

   var user = await _unitOfWork.Users.GetUserRolesPermissionsByIdAsync(userId);
   var permissions = user.UserRoles
       .Select(ur => ur.Role)
       .SelectMany(r => r.RolePermissions)
       .Select(rp => rp.Permission.Name);

   if (permissions.Contains(requirement.Permission))
       context.Succeed(requirement);
}*/

        //not good for long live jwt tokens
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var permission = context.User.FindAll(CustomClaims.Permission).Select(c => c.Value).ToHashSet();

            if (permission.Contains(requirement.Permission))
                 context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
