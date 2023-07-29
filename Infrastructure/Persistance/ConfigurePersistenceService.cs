using Application.Common.Interfaces.Data;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Interceptors;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Initialisers;
using Infrastructure.Persistance.Repositories;
using Infrastructure.Persistance.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    internal static class ConfigurePersistenceService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection source, IConfiguration configuration)
        {
            source.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            source.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            source.AddScoped<AuditableEntitySaveChangesInterceptor>();
            source.AddScoped<ApplicationDbContextInitialiser>();
            source.AddScoped<IUnitOfWork, UnitOfWork>();
            source.AddScoped<ModelSeeder>();

            return source;
        }
    }
}
