using Application.Common.Helpers;
using Application.Common.Interfaces.FilesStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.FileStorage
{
    internal static class ConfigureFilesService
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection source)
        {
            source.AddScoped<IFileStorage, LocalFileStorageService>();

            return source;
        }

        public static IApplicationBuilder UseFileStorage(this IApplicationBuilder source)
        {
            source.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(PathHelper.GetAbsolutePath(FileStorageConstants.Root)),
                RequestPath = '/' + FileStorageConstants.Root
            });

            return source;
        }
    }
}
