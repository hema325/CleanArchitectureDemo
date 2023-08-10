using Application.Common.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Notifications
{
    public interface INotificationHubSender
    {
        Task BroadcastAsync(Notification notification);
        Task SendeToUserAsync(string userId, Notification notification);
        Task SendToUsersAsync(IEnumerable<string> userIds, Notification notification);
    }
}
