namespace Application.Authentication.ConfirmEmail
{
    public class ConfirmEmailCommandValidator: AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("The {PropertyName} is required");

            RuleFor(c => c.Token)
                .NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}
