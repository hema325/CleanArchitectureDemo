using Application.Authentication.Common.Specifications;
using Application.Authentication.Exceptions;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.SignOut
{
    public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTime _dateTime;

        public RevokeTokenCommandHandler(IUnitOfWork unitOfWork, IDateTime dateTime)
        {
            _unitOfWork = unitOfWork;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            var token = (await _unitOfWork.Tokens.GetBySpecificationAsync(new GetTokenByValueSpecification(request.RefreshToken))).FirstOrDefault();

            if (token == null || token.Type != TokenTypes.RefreshToken || token.RevokedOn != null || _dateTime.Now >= token.ExpiresOn)
                throw new InvalidTokenException();

            token.RevokedOn = _dateTime.Now;
            _unitOfWork.Tokens.Update(token);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
