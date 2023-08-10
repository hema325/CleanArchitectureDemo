using Application.Common.Interfaces.Notifications;
using Application.Common.Models.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Notifications.Hubs
{
    internal class NotificationHubSenderService: INotificationHubSender
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationHubSenderService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task BroadcastAsync(Notification notification)
        {
            await _hubContext.Clients.All.SendAsync(NotificationMethodsNames.DispNotification, notification);
        }

        public async Task SendeToUserAsync(string userId ,Notification notification)
        {
            await _hubContext.Clients.User(userId).SendAsync(NotificationMethodsNames.DispNotification, notification);
        }

        public async Task SendToUsersAsync(IEnumerable<string> userIds,Notification notification)
        {
            await _hubContext.Clients.Users(userIds).SendAsync(NotificationMethodsNames.DispNotification, notification);
        }
    }
}
