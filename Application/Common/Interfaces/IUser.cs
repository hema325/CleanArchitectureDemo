using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUser
    {
        Task<string> GetUserNameAsync(string id);
        Task<(string, Result)> CreateUserAsync(User user, string password);
        Task<Result> DeleteUserAsync(string id);
        Task<bool> IsInRoleAsync(string id, string role);
        Task<bool> IsEmailConfirmedAsync(string email);
        Task<bool> IsEmailExistedAsync(string email);
        Task<Result> ConfirmEmailAsync(string id, string token);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(string id);
        Task<Result> AddToRoleAsync(string id, string role);
    }
}
