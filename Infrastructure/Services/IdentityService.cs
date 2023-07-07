using Application.Common.Models;
using Infrastructure.Common;
using Infrastructure.Models;
using Infrastructure.Services.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);

            return result.ToResult();
        }

        public async Task<bool> IsInRoleAsync(string userId, string Role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return await _userManager.IsInRoleAsync(user, Role.ToString());
        }

        public async Task<Result> SignInAsync(string userName, string password, bool isPersistent = false, bool lockOutOnFailure = false)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockOutOnFailure);

            return result.Succeeded ? Result.Success : Result.Failure;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
