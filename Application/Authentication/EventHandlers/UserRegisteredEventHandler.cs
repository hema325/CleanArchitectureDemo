using Domain.Common.Events;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.EventHandlers
{
    public class UserRegisteredEventHandler : INotificationHandler<EntityCreatedEvent<User>>
    {
        private readonly ILogger<UserRegisteredEventHandler> _logger;

        public UserRegisteredEventHandler(ILogger<UserRegisteredEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(EntityCreatedEvent<User> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entity {name} ({id}) has been created successfully", nameof(User), notification.Entity.Id);

            return Task.CompletedTask;
        }
    }
}
