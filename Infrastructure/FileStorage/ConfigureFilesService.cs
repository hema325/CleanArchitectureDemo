using Application.Common.Interfaces.FilesStorage;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.FileStorage
{
    internal static class ConfigureFilesService
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection source)
        {
            source.AddScoped<IFileStorage, LocalFileStorageService>();

            return source;
        }
    }
}
