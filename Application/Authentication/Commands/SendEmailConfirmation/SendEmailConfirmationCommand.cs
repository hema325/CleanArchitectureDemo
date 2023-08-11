namespace Application.Authentication.CreateEmailConfirmationToken
{
    public sealed record SendEmailConfirmationCommand(string Email) : IRequest;
}
