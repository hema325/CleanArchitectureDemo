﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(450).ValueGeneratedOnAdd().ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasMaxLength(24).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(24).IsRequired();
            builder.Property(p => p.UserName).HasMaxLength(255);
            builder.Property(p => p.Email).HasMaxLength(255);
        }
    }
}
