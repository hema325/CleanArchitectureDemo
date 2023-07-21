using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasMaxLength(24).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(24).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(24).IsRequired();
        }
    }
}
