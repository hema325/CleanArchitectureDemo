using Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    internal static class SginInResultExtensions
    {
        public static Result ToResult(this SignInResult source)
        {
            if (source.Succeeded)
                return Result.Success;

            var errors = new List<string>();

            if (source.IsNotAllowed)
                errors.Add("Not Allowed to Sgin In");

            if (source.IsLockedOut)
                errors.Add("Acount Is Locked Out");

            return new Result { Succeeded = false, Errors = errors.ToArray() };
        }
    }
}
