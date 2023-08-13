namespace Application.Authentication.Commands.RequestJwtToken
{
    public class RequestJwtTokenCommandValidator: AbstractValidator<RequestJwtTokenCommand>
    {
        public RequestJwtTokenCommandValidator()
        {
            RuleFor(p => p.RefreshToken)
                .NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}
