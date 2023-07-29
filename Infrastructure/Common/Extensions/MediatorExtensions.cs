using Domain.Common.Entities;
using Infrastructure.Persistance.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Extensions
{
    internal static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator source, ApplicationDbContext context, CancellationToken cancellationToken)
        {
            var entities = context.ChangeTracker.Entries<EntityBase>().Where(e => e.Entity.DomainEvents.Any()).Select(e => e.Entity);
            var domainEvents = entities.SelectMany(e => e.DomainEvents);

            foreach (var domainEvent in domainEvents)
                await source.Publish(domainEvent, cancellationToken);

            foreach (var entity in entities)
                entity.ClearDomainEvents();
        }
    }
}
