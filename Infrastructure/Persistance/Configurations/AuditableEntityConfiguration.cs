using Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Configurations
{
    internal static class AuditableEntityConfiguration 
    {
        public static void Configure(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
                if (entity.ClrType.IsAssignableTo(typeof(AuditableEntity)))
                {
                    foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                        property.SetMaxLength(450);
                }
        }
    }
}
