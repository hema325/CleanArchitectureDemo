using Application.Common.Email.Interfaces;
using Infrastructure.Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Emails
{
    internal static class ConfigureEmailService
    {
        public static IServiceCollection AddEmail(this IServiceCollection source,IConfiguration configuration)
        {
            source.AddScoped<IEmailSender, EmailSenderService>();

            source.Configure<EmailSettings>(configuration.GetSection(EmailSettings.SectionName));

            return source;
        }
    }
}
