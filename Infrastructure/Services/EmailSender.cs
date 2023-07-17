using Application.Common.Interfaces;
using Infrastructure.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        public EmailSender(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
        }

        public async Task SendAsync(string to, string subject, string body, IEnumerable<IFormFile> attachments = null)
        {
            var mimeMessage = await GetMimeMessage(to, subject, body, attachments);

            await SendAsync(mimeMessage);
        }

        private async Task<MimeMessage> GetMimeMessage(string to, string subject, string body, IEnumerable<IFormFile> attachments)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.UserName),
                Subject = subject
            };

            email.To.Add(MailboxAddress.Parse(to));
            email.From.Add(new MailboxAddress(_mailSettings.UserName, _mailSettings.DisplayName));

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = body;

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    using var ms = new MemoryStream();
                    await attachment.CopyToAsync(ms);
                    var attachmentBytes = ms.ToArray();

                    bodyBuilder.Attachments.Add(attachment.FileName, attachmentBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            email.Body = bodyBuilder.ToMessageBody();

            return email;
        }

        private async Task SendAsync(MimeMessage email)
        {
            var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
