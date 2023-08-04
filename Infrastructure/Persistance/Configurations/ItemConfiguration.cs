using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(250);
            builder.Property(p => p.ImagePath).HasMaxLength(450).IsUnicode(false);
            builder.HasIndex(p => p.Name).IsUnique(true);
        }
    }
}
