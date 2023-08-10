using Application.Common.Constants;
using Application.Common.Email.Interfaces;
using Application.Common.Interfaces.Notifications;
using Application.Common.Interfaces.Templates;
using Application.Common.Models.Notifications.Email;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Notifications.Email
{
    internal class EmailNotificationSenderService: IEmailNotificationSender
    {
        private readonly IEmailSender _emailSender;
        private readonly ITemplate _template;
        private readonly ILogger<EmailNotificationSenderService> _logger;
        private readonly ITemplateEnvironment _templateEnvironment;

        public EmailNotificationSenderService(IEmailSender emailSender, ITemplate emailTemplate, ILogger<EmailNotificationSenderService> logger, ITemplateEnvironment templateEnvironment)
        {
            _emailSender = emailSender;
            _template = emailTemplate;
            _logger = logger;
            _templateEnvironment = templateEnvironment;
        }

        public async Task SendEmailConfirmedAsync(EmailConfirmedNotification model)
        {
            var template = await _template.GetTemplateByNameAsync(_templateEnvironment.EmailConfirmedTemplate, model);

            var to = model.Email;
            var subject = "Email Confirmation";
            var body = template;

            await _emailSender.SendAsync(to, subject, body);

            _logger.LogInformation("email confirmed message is Sent succssefully to user with email {0}", model.Email);
        }

    }
}
