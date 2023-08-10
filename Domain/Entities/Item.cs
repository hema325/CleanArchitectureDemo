using Domain.Common.Contracts;
using Domain.Common.Entities;
using Domain.ValueObjects;
using System.ComponentModel;

namespace Domain.Entities
{
    public class Item: AuditableEntity,IAggregateRoot
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string? ImagePath { get; set; }
    }
}
