using Application.Common.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor: SaveChangesInterceptor
    {
        private readonly IUser _user;

        public AuditableEntitySaveChangesInterceptor(IUser user)
        {
            _user = user;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            MangeAddedEntities(eventData.Context.ChangeTracker);
            MangeModifiedEntities(eventData.Context.ChangeTracker);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void MangeAddedEntities(ChangeTracker changeTracker)
        {
            var addedEntries = changeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                entry.Entity.CreatedBy = _user.Id;
                entry.Entity.ModifiedBy = _user.Id;
            }
        }

        private void MangeModifiedEntities(ChangeTracker changeTracker)
        {
            var modifiedEntries = changeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                entry.Entity.ModifiedBy = _user.Id;
            }
        }
    }
}
