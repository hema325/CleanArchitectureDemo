using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.FileStorage
{
    internal static class ConfigureFilesService
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection source)
        {
            

            return source;
        }
    }
}
