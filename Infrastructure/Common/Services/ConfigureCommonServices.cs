using Application.Common.Interfaces.Services;
using Infrastructure.Authentication;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services;

namespace Infrastructure.Common.Services
{
    internal static class ConfigureCommonServices
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection source)
        {
            source.AddScoped<IDateTime, DateTimeService>();
            source.AddScoped<ILinkGenerator, LinkGeneratorService>();
            source.AddScoped(typeof(ICsvFileBuilder<>), typeof(CsvFileBuilderService<>));

            return source;
        } 
    }
}
