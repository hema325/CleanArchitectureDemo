using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Repositories;
using Domain.Common.Events;
using Domain.Entities;
using Domain.Enums;

namespace Application.Authentication.SignUp
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Email,
                Email = request.Email,
                HashedPassword = _passwordHasher.HashPassword(request.Password),
                UserRoles = new List<UserRoles>
                {
                    new UserRoles
                    {
                        RoleId = (int)Roles.User
                    }
                }
            };

            await _unitOfWork.Users.CreateAsync(user);
            
            user.AddDomainEvent(new EntityCreatedEvent<User>(user));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
