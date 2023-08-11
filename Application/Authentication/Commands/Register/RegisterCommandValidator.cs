namespace Application.Authentication.SignUp
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.FirstName).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(c => c.LastName).MaximumLength(24).NotEmpty().NotNull();
            RuleFor(c => c.Email).MaximumLength(256).NotEmpty().NotNull();
            RuleFor(c => c.Password).NotEmpty().NotNull();
        }
    }
}
