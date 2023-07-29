

using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistance.Context;

namespace Infrastructure.Persistance.Repositories
{
    internal class UserRolesRepository : BaseRepository<UserRoles>, IUserRolesRepository
    {
        public UserRolesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
