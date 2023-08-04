using Domain.Enums;
using Microsoft.AspNetCore.Authorization;


namespace Infrastructure.Authentication.Permissions
{
    public class HaveRolesAttribute: AuthorizeAttribute
    {
        public HaveRolesAttribute(params Roles[] roles)
        {
            Roles = String.Join(",", roles.Select(r => r.ToString()));
        }
    }
}
