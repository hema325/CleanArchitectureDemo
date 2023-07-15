using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAuthentication
    {
        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<Result> SignInAsync(string userName, string password, bool rememberMe);
        Task SignInAsync(string Id);
        Task SignOutAsync();
    }
}
