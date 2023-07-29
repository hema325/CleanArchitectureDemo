using Application.Common.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    internal class RandomTokenGeneratorService: IRandomTokenGenerator
    {
        public string GeneratorToken(int length = 32)
        {
            var token = new byte[length];
            var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(token);
            return Convert.ToBase64String(token);
        }
    }
}
