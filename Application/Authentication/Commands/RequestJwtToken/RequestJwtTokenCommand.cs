using Application.Authentication.Models;

namespace Application.Authentication.Commands.RequestJwtToken
{
    public sealed record RequestJwtTokenCommand(string RefreshToken) : IRequest<AuthResult>;
}
