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
            builder.HasKey(i => new { i.Id });
            builder.Property(p => p.ImagePath).HasMaxLength(450).IsUnicode(false);

            builder.OwnsOne(i => i.Name, builder =>
            {
                builder.WithOwner().HasForeignKey("ItemId");
                builder.Property(p => p.Value).HasMaxLength(250).HasColumnName("Name").IsRequired(false);
                builder.HasIndex(p => p.Value).IsUnique();
            });

            //instead of OwnsOne if the value object has only one property
            //builder.Property(p => p.Name).HasMaxLength(250).HasConversion(name => name.Value, value => Name.Create(value));
            //builder.HasIndex(p => p.Name).IsUnique(true);
        }
    }
}
