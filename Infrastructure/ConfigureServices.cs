using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Models;
using Infrastructure.Interceptors;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Files;
using Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Identity.Services;
using Infrastructure.Persistance.DbInitializer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection source,IConfiguration configuration)
        {
            #region Database
            source.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            source.AddIdentity<ApplicationUser, IdentityRole>(options=>options.SignIn.RequireConfirmedEmail = true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            #endregion

            #region scoped services
            source.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            source.AddScoped<AuditableEntitySaveChangesInterceptor>();
            source.AddScoped<IAuthentication, AuthenticationService>();
            source.AddScoped<IUser, UserService>();
            source.AddScoped<IDateTime, DateTimeService>();
            source.AddScoped(typeof(ICsvFileBuilder<>), typeof(CsvFileBuilder<>));
            source.AddScoped<IEmailSender, EmailSender>();
            source.AddScoped<IDbInitializer, DbInitializer>();
            #endregion

            #region configurations
            //source.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            #endregion

            return source;
        }
    }
}
