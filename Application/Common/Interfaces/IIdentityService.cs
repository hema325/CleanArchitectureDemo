using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Identity
{
    public interface IIdentityService
    {
        Task<Result> DeleteUserAsync(string userId);
        Task<bool> IsInRoleAsync(string userId, string Role);
        Task<Result> SignInAsync(string userName, string password, bool isPersistent = false, bool lockOutOnFailure = false);
        Task SignOutAsync();
    }
}
