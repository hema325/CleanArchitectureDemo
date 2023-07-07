using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }

        #region DomainEvents

        private readonly List<BaseEvent> _domainEvents = new();
        
        [NotMapped]
        public IReadOnlyList<BaseEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(BaseEvent baseEvent) => _domainEvents.Add(baseEvent);
        public void RemoveDomainEvent(BaseEvent baseEvent) => _domainEvents.Remove(baseEvent);
        public void ClearDomainEvents() => _domainEvents.Clear();

        #endregion
    }
}
