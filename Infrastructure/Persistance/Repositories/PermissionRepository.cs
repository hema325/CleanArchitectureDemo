using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    internal class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Permission>> GetByUserId(string userId)
        {
            return await _context
                .Permissions
                .Where(p => p.RolePermissions
                    .Any(rp => rp.Role.UserRoles
                        .Any(ur => ur.UserId == userId)))
                .ToListAsync();
        }
    }
}
