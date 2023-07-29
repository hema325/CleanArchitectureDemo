using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Identity;
using Infrastructure.Authentication.Jwt;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Authentication
{
    internal static class ConfigureAuthenticationService
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection source, IConfiguration configuration)
        {

            source.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();

            source.AddScoped<IJwtTokenGenerator, JwtTokenGeneratorService>();
            source.AddScoped<ICurrentUser, CurrentUserService>();
            source.AddScoped<IRandomTokenGenerator, RandomTokenGeneratorService>();
            source.AddScoped<IPasswordHasher, PasswordHasherService>();
            source.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));


            source.ConfigureOptions<JwtBearerOptionsConfiguration>();
            source.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            return source;
        }
    }
}
