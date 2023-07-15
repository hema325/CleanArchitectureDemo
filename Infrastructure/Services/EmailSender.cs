using Application.Common.Interfaces;
using Domain.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        public EmailSender(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
        }

        public async Task SendAsync(MailMessage message)
        {
            using var client = new SmtpClient()
            {
                Host = _mailSettings.Host,
                Port = _mailSettings.Port,
                Credentials = new NetworkCredential(_mailSettings.UserName, _mailSettings.Password),
                EnableSsl = true
            };

            message.From = new MailAddress(_mailSettings.EmailFrom, _mailSettings.DisplayName);

            await client.SendMailAsync(message);
        }
    }
}
