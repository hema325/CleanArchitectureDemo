using Application.Authentication.Common.Specifications;
using Application.Authentication.Exceptions;
using Application.Authentication.Models;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.RequestJwtToken
{
    internal class RequestJwtTokenCommandHandler : IRequestHandler<RequestJwtTokenCommand, AuthResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRandomTokenGenerator _tokenProvider;
        private readonly IDateTime _dateTime;

        public RequestJwtTokenCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator, IRandomTokenGenerator tokenProvider, IDateTime dateTime)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
            _tokenProvider = tokenProvider;
            _dateTime = dateTime;
        }

        public async Task<AuthResult> Handle(RequestJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var token = (await _unitOfWork.Tokens.GetBySpecificationAsync(new GetTokenByValueSpecification(request.RefreshToken))).FirstOrDefault();

            if (token == null || token.Type != TokenTypes.RefreshToken || token.RevokedOn != null || _dateTime.Now >= token.ExpiresOn)
                throw new InvalidTokenException();

            var user = (await _unitOfWork.Users.GetBySpecificationAsync(new GetUserByIdSpecification(token.UserId))).FirstOrDefault();

            token.RevokedOn = _dateTime.Now;
            _unitOfWork.Tokens.Update(token);

            var refreshToken = new Token
            {
                Value = _tokenProvider.GeneratorToken(),
                Type = TokenTypes.RefreshToken,
                CreatedOn = _dateTime.Now,
                ExpiresOn = _dateTime.Now.AddHours(1)
            };
            
            user.Tokens = new List<Token>
            {
                refreshToken
            };

            _unitOfWork.Users.Update(user);
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
