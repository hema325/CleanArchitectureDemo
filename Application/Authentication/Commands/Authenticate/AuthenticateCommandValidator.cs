namespace Application.Authentication.SignIn
{
    public class AuthenticateCommandValidator: AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            RuleFor(c => c.Email)
                .Matches(@"^[\w\d]+@\w+.\w+$").WithMessage("the {PropertyName} is not valid")
                .MaximumLength(256).WithMessage("The {PropertyName} must have maximum length of {MaxLength}")
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}
