using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistance.Context;

namespace Infrastructure.Persistance.Repositories
{
    internal class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
