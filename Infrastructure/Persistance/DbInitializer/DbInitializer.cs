using Infrastructure.Data;
using Infrastructure.Models;
using Infrastructure.Persistance.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DbInitializer
{
    internal class DbInitializer: IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext context,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();
            await SeedAsync();
        }

        private async Task SeedAsync()
        {
            await DefaultUser.SeedAsync(_userManager);
            await DefaultRoles.SeedAsync(_roleManager);
        }
    }
}
