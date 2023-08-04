using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configurations
{
    internal class RolePermissionsConfiguration : IEntityTypeConfiguration<RolePermissions>
    {
        public void Configure(EntityTypeBuilder<RolePermissions> builder)
        {
            builder.HasKey(p => new { p.RoleId, p.PermissionId });
        }
    }
}
