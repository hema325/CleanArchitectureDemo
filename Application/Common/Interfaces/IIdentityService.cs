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
        Task<string> GetUserName(string userId);
    }
}
