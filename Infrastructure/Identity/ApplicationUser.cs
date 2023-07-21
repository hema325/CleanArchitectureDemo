using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    internal class ApplicationUser : IdentityUser
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }


        public static explicit operator ApplicationUser(UserModel user)
            => new ApplicationUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed
            };

        public static explicit operator UserModel(ApplicationUser applicationUser)
            => new UserModel
            {
                Id = applicationUser.Id,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                EmailConfirmed = applicationUser.EmailConfirmed,
                PhoneNumber = applicationUser.PhoneNumber,
                PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed
            };
    }
}
