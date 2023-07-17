using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Services
{
    internal class UserService : IUser
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserNameAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return user.UserName;
        }

        public async Task<(string, Result)> CreateUserAsync(UserModel user, string password)
        {
            var applicationUser = (ApplicationUser)user;

            var result = await _userManager.CreateAsync(applicationUser, password);

            return (applicationUser.Id, result.ToResult());
        }

        public async Task<Result> AddToRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);

            var result = await _userManager.AddToRoleAsync(user, role);

            return result.ToResult();
        }

        public async Task<Result> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var result = await _userManager.DeleteAsync(user);

            return result.ToResult();
        }

        public async Task<bool> IsInRoleAsync(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);

            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> IsEmailConfirmedAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user.EmailConfirmed;
        }

        public async Task<bool> IsEmailExistedAsync(string email)
        {
            return await _userManager.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            return (UserModel)await _userManager.FindByEmailAsync(email);
        }

        public async Task<UserModel> GetByIdAsync(string id)
        {
            return (UserModel)await _userManager.FindByIdAsync(id);
        }
    }
}
