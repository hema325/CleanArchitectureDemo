namespace Application.Authentication.SignUp
{
    public sealed record RegisterCommand(string FirstName,string LastName,string Email,string Password) : IRequest;
}
