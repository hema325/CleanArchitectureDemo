using Application.Authentication.SignOut;

namespace Application.Authentication.Commands.RevokeToken
{
    public class RevokeTokenCommandValidator: AbstractValidator<RevokeTokenCommand>
    {
        public RevokeTokenCommandValidator()
        {
            RuleFor(p => p.RefreshToken)
                .NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}
