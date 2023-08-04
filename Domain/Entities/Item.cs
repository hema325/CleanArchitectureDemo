using Domain.Common.Entities;
using Domain.Common.Interfaces;
using System.ComponentModel;

namespace Domain.Entities
{
    public class Item: AuditableEntity,IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Description(".jpg,.png,.jpeg")]
        public string? ImagePath { get; set; }
    }
}
