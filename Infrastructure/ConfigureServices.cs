using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Persistance;
using Infrastructure.Emails;
using Infrastructure.Authentication;
using Infrastructure.Common.Services;
using Infrastructure.FileStorage;
using Microsoft.AspNetCore.Builder;
using Infrastructure.Persistance.Initialisers;

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
            source.AddCommonServices();

            return source;
        }

        public async static Task<IServiceProvider> InitializeDatabaseAsync(this IServiceProvider source)
        {
            await source.CreateScope()
                .ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>()
                .InitializeAsync();

            return source;
        }
    }
}
