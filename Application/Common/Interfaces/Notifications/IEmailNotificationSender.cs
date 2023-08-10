using Application.Common.Models.Notifications.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Notifications
{
    public interface IEmailNotificationSender
    {
        Task SendEmailConfirmedAsync(EmailConfirmedNotification model);
    }
}
