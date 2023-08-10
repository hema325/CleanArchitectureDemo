using Microsoft.AspNetCore.Builder;
using Serilog;

namespace Infrastructure.Serilog
{
    internal static class ConfigureSerilogService
    {
        public static ConfigureHostBuilder UseSerilog(this ConfigureHostBuilder source)
        {
            source.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

            return source;
        }
    }
}
