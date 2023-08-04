using Domain.Common.Events;
using Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common.Entities
{
    public abstract class EntityBase: IEntity
    {
        private readonly List<EventBase> _domainEvents = new();

        [NotMapped]
        public IReadOnlyList<EventBase> DomainEvents => _domainEvents;

        public void AddDomainEvent(EventBase baseEvent) => _domainEvents.Add(baseEvent);
        public void RemoveDomainEvent(EventBase baseEvent) => _domainEvents.Remove(baseEvent);
    }
}
