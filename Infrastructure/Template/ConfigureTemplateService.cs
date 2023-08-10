using Application.Common.Constants;
using Application.Common.Interfaces.Templates;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Templates
{
    internal static class ConfigureTemplateService
    {
        public static IServiceCollection AddTemplate(this IServiceCollection source)
        {
            source.AddScoped<ITemplate, TemplateService>();
            source.AddScoped<ITemplateEnvironment, TemplateEnvironmentService>();

            return source;
        }
    }
}
