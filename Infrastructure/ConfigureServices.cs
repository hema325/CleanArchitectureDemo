using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Persistance;
using Infrastructure.Emails;
using Infrastructure.Authentication;
using Infrastructure.Common.Services;
using Infrastructure.FileStorage;
using Microsoft.AspNetCore.Builder;
using Infrastructure.Persistance.Initialisers;
using Infrastructure.Templates;
using Infrastructure.Notifications;
using Microsoft.AspNetCore.Routing;
using Infrastructure.Middleware;
using Infrastructure.Serilog;
using Infrastructure.Cors;
using Infrastructure.Caching;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection source,IConfiguration configuration)
        {
            source.AddHttpContextAccessor();
            source.AddAuthentication(configuration);
            source.AddEmail(configuration);
            source.AddFileStorage();
            source.AddPersistence(configuration);
            source.AddTemplate();
            source.AddNotifications();
            source.AddCommonServices();
            source.AddMiddleware();
            source.AddCorsService(configuration);
            source.AddCaching(configuration);
            return source;
        }

        public async static Task<IServiceProvider> InitializeDatabaseAsync(this IServiceProvider source)
        {
            await source.CreateScope()
                .ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>()
                .InitializeAsync();

            return source;
        }

        public static IEndpointRouteBuilder MapInfrastructure(this IEndpointRouteBuilder source)
        {
            source.MapNotifications();

            return source;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder source)
        {
            source.UseCorsService();
            source.UseAuth();
            source.UseFileStorage();
            source.UseMiddleware();

            return source;
        }

        public static ConfigureHostBuilder UseConfigurationFromInfrastructure(this ConfigureHostBuilder source)
        {
            source.UseSerilog();

            return source;
        }
    }
}
