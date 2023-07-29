using Domain.Common.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Entities
{
    public abstract class EntityBase
    {
        #region DomainEvents

        private readonly List<EventBase> _domainEvents = new();

        [NotMapped]
        public IReadOnlyList<EventBase> DomainEvents => _domainEvents;

        public void AddDomainEvent(EventBase baseEvent) => _domainEvents.Add(baseEvent);
        public void RemoveDomainEvent(EventBase baseEvent) => _domainEvents.Remove(baseEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();

        #endregion
    }
}
