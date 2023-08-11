namespace Application.Authentication.ConfirmEmail
{
    public sealed record ConfirmEmailCommand(string UserId,string Token): IRequest;
}
