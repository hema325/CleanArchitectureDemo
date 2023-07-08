using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Models;
using Infrastructure.Interceptors;
using Infrastructure.Services;
using Infrastructure.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Files;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection source,IConfiguration configuration)
        {
            source.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            source.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            source.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            source.AddScoped<IUser, UserService>();
            source.AddScoped<AuditableEntitySaveChangesInterceptor>();
            source.AddScoped<IIdentityService, IdentityService>();
            source.AddScoped<IDateTime, DateTimeService>();
            source.AddScoped(typeof(ICsvFileBuilder<>), typeof(CsvFileBuilder<>));
            return source;
        }
    }
}
