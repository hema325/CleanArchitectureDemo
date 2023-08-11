using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Middleware
{
    internal static class ConfigureMiddleware
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection source)
        {
            source.AddScoped<RequestLoggingMiddleware>();
            source.AddScoped<ResponseLoggingMiddleware>();
            source.AddScoped<GlobalExceptionMiddleware>();

            return source;
        }

        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder source)
        {
            source.UseMiddleware<RequestLoggingMiddleware>();
            source.UseMiddleware<ResponseLoggingMiddleware>();
            //source.UseMiddleware<GlobalExceptionMiddleware>();

            return source;
        }
    }
}
