﻿using Domain.Constanst;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeding
{
    public static class ModuleSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var firstRole = new ApplicationRole
            {
                Name = Roles.Admin
            };

            var secondRole = new ApplicationRole
            {
                Name = Roles.User
            };

            builder.Entity<ApplicationRole>().HasData(firstRole, secondRole);
        }
    }
}