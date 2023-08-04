using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Identity;
using Infrastructure.Authentication.Filters;
using Infrastructure.Authentication.Jwt;
using Infrastructure.Authentication.Permissions;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
            source.AddAuthorization();  //optional cause it's  already added by default

            source.AddScoped<IJwtTokenGenerator, JwtTokenGeneratorService>();
            source.AddScoped<ICurrentUser, CurrentUserService>();
            source.AddScoped<IRandomTokenGenerator, RandomTokenGeneratorService>();
            source.AddScoped<IPasswordHasher, PasswordHasherService>();
            source.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
            source.AddSingleton<IAuthorizationHandler,PermissionAuthorizationHandler>();
            source.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();



            source.ConfigureOptions<JwtBearerOptionsConfiguration>();
            source.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            source.Configure<ApiKeySettings>(configuration.GetSection(ApiKeySettings.SectionName));
            return source;
        }
    }
}
