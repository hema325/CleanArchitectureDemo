namespace Application.Authentication.SignUp
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .MaximumLength(24).WithMessage("The {PropertyName} must have maximum length of 24")
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(c => c.LastName)
                .MaximumLength(24).WithMessage("The {PropertyName} must have maximum length of 24")
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(c => c.Email)
                .Matches(@"^[\w\d]+@\w+.\w+$").WithMessage("the {PropertyName} is not valid")
                .MaximumLength(256).WithMessage("The {PropertyName} must have maximum length of 256")
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(c => c.Password)
                .Must(p => IsPasswordValid(p)).WithMessage("The {PropertyName} must contains capital/small letters, digits and spcial charachters")
                .Length(6,24).WithMessage("The {PropertyName} length must be between 6 and 24")
                .NotEmpty().WithMessage("The {PropertyName} is required");
        }

        private bool IsPasswordValid(string password)
        {
            var specialCharacters = new[] { '!', '@', '#', '$', '%', '^', '&', '*' };

            return password.Any(c => char.IsUpper(c))
                && password.Any(c => char.IsLower(c))
                && password.Any(c => char.IsDigit(c))
                && password.Any(c => specialCharacters.Any(ch => ch == c));
        }
    }
}
