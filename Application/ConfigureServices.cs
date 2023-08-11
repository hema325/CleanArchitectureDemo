using Application.Common.Behaviors;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
