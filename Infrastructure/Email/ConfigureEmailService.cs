using Application.Common.Email.Interfaces;
using Infrastructure.Email;
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
            source.AddScoped<IEmailTemplate, EmailTemplateService>();

            source.Configure<MailSettings>(configuration.GetSection(MailSettings.SectionName));

            return source;
        }
    }
}
