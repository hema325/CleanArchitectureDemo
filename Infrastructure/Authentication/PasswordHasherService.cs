using Application.Common.Interfaces.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Authentication
{
    internal class PasswordHasherService : IPasswordHasher
    {
        private readonly IPasswordHasher<object> _passwordHasher;

        public PasswordHasherService(IPasswordHasher<object> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(string password)
            => _passwordHasher.HashPassword(new object(), password);

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
            => _passwordHasher.VerifyHashedPassword(new object(), hashedPassword, providedPassword) == PasswordVerificationResult.Success;
    }
}
