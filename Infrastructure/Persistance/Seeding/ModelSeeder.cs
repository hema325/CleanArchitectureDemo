using Application.Common.Interfaces.Authentication;
using Domain.Entities;
using Domain.Enums;
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
            var roles = new[]
            {
                new Role
                {
                    Id = 1,
                    Name = Roles.Admin.ToString(),
                    Description = "Person with admin role can do any thing on this api"
                },
                new Role
                {
                    Id = 2,
                    Name = Roles.User.ToString(),
                    Description = "Person with User role can do specific things on this api"
                }
            };

            builder.Entity<Role>().HasData(roles);

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
                    RoleId = roles[0].Id
                }
            };

            builder.Entity<UserRoles>().HasData(userRoles);

            var items = new[]
            {
                new Item
                {
                    Id = 1,
                    Name = "Default Name"
                }
            };

            builder.Entity<Item>().HasData(items);
        }
    }
}