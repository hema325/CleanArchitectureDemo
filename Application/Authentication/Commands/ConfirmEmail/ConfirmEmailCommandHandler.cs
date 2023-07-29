using Application.Authentication.Common.Specifications;
using Application.Authentication.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Enums;


namespace Application.Authentication.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTime _dateTime;

        public ConfirmEmailCommandHandler(IUnitOfWork unitOfWork, IDateTime dateTime)
        {
            _unitOfWork = unitOfWork;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = (await _unitOfWork.Users.GetBySpecificationAsync(new GetUserByIdSpecification(request.UserId))).FirstOrDefault();
            var token = (await _unitOfWork.Tokens.GetBySpecificationAsync(new GetTokenByValueSpecification(request.Token))).FirstOrDefault();

            if (user == null || token == null || user.Id != token.UserId || _dateTime.Now >= token.ExpiresOn || token.RevokedOn != null || token.Type != TokenTypes.EmailVerificationToken)
                throw new InvalidTokenException();

            user.IsEmailConfirmed = true;
            token.RevokedOn = _dateTime.Now;

            _unitOfWork.Users.Update(user);
            _unitOfWork.Tokens.Update(token);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
