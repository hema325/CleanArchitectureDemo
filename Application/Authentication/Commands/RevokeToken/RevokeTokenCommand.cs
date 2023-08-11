namespace Application.Authentication.SignOut
{
    public sealed record RevokeTokenCommand (string RefreshToken): IRequest;
}
