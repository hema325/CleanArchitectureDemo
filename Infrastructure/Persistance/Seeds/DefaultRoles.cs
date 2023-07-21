using Domain.Constanst;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Seeds
{
    internal static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            var firstRole = new IdentityRole
            {
                Name = Roles.Admin
            };

            var secondRole = new IdentityRole
            {
                Name = Roles.User
            };

            await roleManager.CreateAsync(firstRole);
            await roleManager.CreateAsync(secondRole);
        }
    }
}
