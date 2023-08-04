using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.Permissions
{
    public class HasPermissionAttribute: AuthorizeAttribute
    {
        public HasPermissionAttribute(Domain.Enums.Permissions permission)
        {
            Policy = permission.ToString(); //benefits of it we can provide a custom handler if we used role with it without using the default key of the role
        }
    }
}
