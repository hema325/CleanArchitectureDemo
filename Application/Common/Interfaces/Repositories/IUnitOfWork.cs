using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IItemRepository Items { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        ITokenRepository Tokens { get; }
        IUserRolesRepository UserRoles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
