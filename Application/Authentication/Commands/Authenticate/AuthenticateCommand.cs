using Application.Authentication.Models;

namespace Application.Authentication.SignIn
{
    public sealed record AuthenticateCommand(string Email,string Password): IRequest<AuthResult>;
}
