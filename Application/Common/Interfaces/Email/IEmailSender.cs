using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Email.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body, IEnumerable<IFormFile> attachments = null);
    }
}
