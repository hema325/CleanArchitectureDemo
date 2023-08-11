using Application.Common.Interfaces.Identity;
using Application.Common.Interfaces.Services;
using Domain.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors
{
    internal class AuditableEntitySaveChangesInterceptor: SaveChangesInterceptor
    {
        private readonly ICurrentUser _user;
        private readonly IDateTime _dateTime;

        public AuditableEntitySaveChangesInterceptor(ICurrentUser user, IDateTime dateTime)
        {
            _user = user;
            _dateTime = dateTime;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var changeTracker = eventData.Context.ChangeTracker;

            MangeAddedEntities(changeTracker);
            MangeModifiedEntities(changeTracker);
            MangeSoftDeletedEntities(changeTracker);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void MangeAddedEntities(ChangeTracker changeTracker)
        {
            var addedEntries = changeTracker.Entries<IAuditableEntity>().Where(e => e.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                entry.Entity.CreatedOn = _dateTime.Now;
                entry.Entity.CreatedBy = _user.Id;
                entry.Entity.ModifiedOn = _dateTime.Now;
                entry.Entity.ModifiedBy = _user.Id;
            }
        }

        private void MangeModifiedEntities(ChangeTracker changeTracker)
        {
            var modifiedEntries = changeTracker.Entries<IAuditableEntity>().Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                entry.Entity.ModifiedOn = _dateTime.Now;
                entry.Entity.ModifiedBy = _user.Id;
            }
        }

        private void MangeSoftDeletedEntities(ChangeTracker changeTracker)
        {
            var deletedEntries = changeTracker.Entries<ISoftDeletableEntity>().Where(e => e.State == EntityState.Deleted);

            foreach (var entry in deletedEntries)
            {
                if (entry.Entity is ISoftDeletableEntity entity)
                {
                    entry.State = EntityState.Unchanged;
                    entity.DeletedOn = _dateTime.Now;
                    entity.DeletedBy = _user.Id;
                }
                else if(entry.Metadata.IsOwned() && entry.Metadata.FindOwnership().PrincipalEntityType.ClrType.IsAssignableTo(typeof(ISoftDeletableEntity)))
                {
                    entry.State = EntityState.Unchanged;
                }
            }
        }
    }
}
