using Application.Authentication.Common.Specifications;
using Application.Authentication.Exceptions;
using Application.Authentication.Models;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.SignIn
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRandomTokenGenerator _tokenProvider;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IDateTime _dateTime;

        public AuthenticateCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator, IRandomTokenGenerator tokenProvider, IPasswordHasher passwordHasher, IDateTime dateTime)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
            _tokenProvider = tokenProvider;
            _passwordHasher = passwordHasher;
            _dateTime = dateTime;
        }

        public async Task<AuthResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Users.GetBySpecificationAsync(new GetUserByEmailSpecification(request.Email))).FirstOrDefault();

            if (user == null || !_passwordHasher.VerifyHashedPassword(user.HashedPassword, request.Password))
                throw new SignInException();

            if (!user.IsEmailConfirmed)
                throw new EmailConfirmationException();

            var refreshToken = new Token
            {
                Value = _tokenProvider.GeneratorToken(),
                Type = TokenTypes.RefreshToken,
                CreatedOn = _dateTime.Now,
                ExpiresOn = _dateTime.Now.AddHours(1),
                UserId = user.Id
            };

            await _unitOfWork.Tokens.CreateAsync(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            var jwtTokenResult = await _jwtTokenGenerator.GenerateTokenAsync(await _unitOfWork.Users.GetUserClaimsAsync(user.Id));

            return new AuthResult
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                JwtToken = jwtTokenResult.Token,
                JwtTokenExpiration = jwtTokenResult.ExpiresOn,
                RefreshToken = refreshToken.Value,
                RefreshTokenExpiration = refreshToken.ExpiresOn
            };
        }
    }
}
