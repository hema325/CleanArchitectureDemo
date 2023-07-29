using Application.Common.Behaviors;
using Application.Items.EventHandlers;
using Domain.Common.Events;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection source)
        {
            source.AddMediatR(Assembly.GetExecutingAssembly());
            source.AddAutoMapper(Assembly.GetExecutingAssembly());
            source.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            source.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            source.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            source.AddScoped(typeof(IRequestPreProcessor<>), typeof(LogginBehavior<>));

            return source;
        }
    }
}
