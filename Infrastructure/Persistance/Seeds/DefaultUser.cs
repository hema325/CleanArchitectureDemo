using Domain.Constanst;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Seeds
{
    internal class DefaultUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser
            {
                FirstName = "Ibrahim",
                LastName = "Moawad",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                PhoneNumber = "+20222222222",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };


            if (userManager.FindByEmailAsync(user.Email) == null)
            {
                var result = await userManager.CreateAsync(user, "Hema123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                    await userManager.AddToRoleAsync(user, Roles.User);
                }
            }
        }
    }
}
