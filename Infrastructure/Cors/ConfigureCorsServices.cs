using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cors
{
    internal static class ConfigureCorsServices
    {
        public static IServiceCollection AddCorsService(this IServiceCollection source, IConfiguration configuration)
        {
            source.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyNames.CorsPolicy,builder =>
                {
                    var settings = configuration.GetSection(CorsSettings.SectionName).Get<CorsSettings>();

                    builder.WithOrigins(settings.Origins);
                    builder.WithMethods(settings.Methods);
                    builder.WithHeaders(settings.Headers);
                });
            });

            return source;
        }

        public static IApplicationBuilder UseCorsService(this IApplicationBuilder source)
        {
            source.UseCors(CorsPolicyNames.CorsPolicy);

            return source;
        }
    }
}
