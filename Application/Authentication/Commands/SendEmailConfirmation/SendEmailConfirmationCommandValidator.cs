namespace Application.Authentication.CreateEmailConfirmationToken
{
    public class SendEmailConfirmationCommandValidator: AbstractValidator<SendEmailConfirmationCommand>
    {
        public SendEmailConfirmationCommandValidator()
        {
            RuleFor(c => c.Email)
                .Matches(@"^[\w\d]+@\w+.\w+$").WithMessage("the {PropertyName} is not valid")
                .MaximumLength(256).WithMessage("The {PropertyName} must have maximum length of 256")
                .NotEmpty().WithMessage("The {PropertyName} is required");
        }
    }
}
