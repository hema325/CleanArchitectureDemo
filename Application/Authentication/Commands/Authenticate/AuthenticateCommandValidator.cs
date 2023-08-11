namespace Application.Authentication.SignIn
{
    public class AuthenticateCommandValidator: AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            RuleFor(c => c.Email).MaximumLength(256).NotEmpty().NotNull();
            RuleFor(c => c.Password).NotEmpty().NotNull();
        }
    }
}
