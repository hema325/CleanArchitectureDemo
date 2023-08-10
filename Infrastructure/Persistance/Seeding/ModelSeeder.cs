using Application.Common.Interfaces.Authentication;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Seeding
{
    internal class ModelSeeder
    {
        private readonly IPasswordHasher _passwordHasher;

        public ModelSeeder(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public void Seed(ModelBuilder builder)
        {
            var permissions = Enum
                .GetValues<Permissions>()
                .Select(p => new Permission { Id = (int)p, Name = p.ToString() });

            builder.Entity<Permission>().HasData(permissions);

            var roles = Enum
                .GetValues<Roles>()
                .Select(r => new Role { Id = (int)r, Name = r.ToString() });

            builder.Entity<Role>().HasData(roles);

            var rolePermissions = new[]
            {
                new RolePermissions
                {
                    RoleId = (int)Roles.Admin,
                    PermissionId = (int)Permissions.ReadWrite
                },
                new RolePermissions
                {
                    RoleId = (int)Roles.User,
                    PermissionId = (int) Permissions.ReadOnly
                }
            };

            builder.Entity<RolePermissions>().HasData(rolePermissions);

            var users = new[]
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "ibrahim",
                    LastName = "Moawad",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    HashedPassword =  _passwordHasher.HashPassword("Password"),
                    IsEmailConfirmed = true
                }
            };

            builder.Entity<User>().HasData(users);

            var userRoles = new[]
            {
                new UserRoles
                {
                    UserId = users[0].Id,
                    RoleId = (int)Roles.Admin
                }
            };

            builder.Entity<UserRoles>().HasData(userRoles);

            var items = new[]
            {
                new Item
                {
                    Id = 1
                }
            };

            builder.Entity<Item>().HasData(items);

            var itemsNames = new[]
            {
                new
                {
                    ItemId = 1,
                    Value = "Default Name"
                }
            };

            builder.Entity<Item>().OwnsOne(i => i.Name).HasData(itemsNames);
        }
    }
}