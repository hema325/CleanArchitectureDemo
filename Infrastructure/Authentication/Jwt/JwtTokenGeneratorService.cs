using Application.Authentication.Common.Models;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication.Jwt
{
    internal class JwtTokenGeneratorService : IJwtTokenGenerator
    {
        private readonly IDateTime _dateTime;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGeneratorService(IDateTime dateTime, IOptions<JwtSettings> jwtOptions)
        {
            _dateTime = dateTime;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<TokenResult> GenerateTokenAsync(IEnumerable<Claim> claims)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: _dateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredential);

            return new TokenResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpiresOn = jwtSecurityToken.ValidTo
            };
        }
    }
}
