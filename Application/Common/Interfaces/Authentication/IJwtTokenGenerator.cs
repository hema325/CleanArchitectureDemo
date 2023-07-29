using Application.Authentication.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        Task<TokenResult> GenerateTokenAsync(IEnumerable<Claim> claims);
    }
}
