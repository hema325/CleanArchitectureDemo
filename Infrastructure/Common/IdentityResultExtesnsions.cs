using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    internal static class IdentityResultExtesnsions
    {
        public static Result ToResult(this IdentityResult source)
        {
            if (source.Succeeded)
                return Result.Success;

            return new Result { Succeeded = false, Errors = source.Errors.Select(e => e.Description).ToArray() };
        }
    }
}
