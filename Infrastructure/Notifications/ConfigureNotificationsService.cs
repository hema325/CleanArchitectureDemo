using Application.Common.Interfaces.Notifications;
using Infrastructure.Notifications.Email;
using Infrastructure.Notifications.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Notifications
{
    internal static class ConfigureNotificationsService
    {
        public static IServiceCollection AddNotifications(this IServiceCollection source)
        {
            source.AddSignalR();

            source.AddScoped<IEmailNotificationSender, EmailNotificationSenderService>();
            source.AddScoped<INotificationHubSender, NotificationHubSenderService>();

            return source;
        }

        public static IEndpointRouteBuilder MapNotifications(this IEndpointRouteBuilder source)
        {
            source.MapHub<NotificationHub>("/Hubs/notificationHub",options =>
            {
                options.CloseOnAuthenticationExpiration = true;
            });

            return source;
        }
    }
}
