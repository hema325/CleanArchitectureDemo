using Application.Common.Interfaces.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Caching
{
    internal static class ConfigureCachingService
    {
        public static IServiceCollection AddCaching(this IServiceCollection source,IConfiguration configuration)
        {
            var settings = configuration.GetSection(CacheSettings.SectionName).Get<CacheSettings>();

            if (settings.UseRedis)
                source.AddStackExchangeRedisCache(options => options.Configuration = settings.RedisConnecting);
            else
                source.AddDistributedMemoryCache(); // it will use local memory

            source.AddScoped<ICacheService, DistributedMemoryCacheService>();


            return source;
        }
    }
}
