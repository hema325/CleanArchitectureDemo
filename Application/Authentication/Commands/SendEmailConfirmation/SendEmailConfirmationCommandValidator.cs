namespace Application.Authentication.CreateEmailConfirmationToken
{
    public class SendEmailConfirmationCommandValidator: AbstractValidator<SendEmailConfirmationCommand>
    {
        public SendEmailConfirmationCommandValidator()
        {
            RuleFor(c => c.Email).MaximumLength(256).NotEmpty().NotNull();
        }
    }
}
