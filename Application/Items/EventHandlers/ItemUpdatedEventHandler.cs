using Domain.Common.Entities;
using Domain.Common.Events;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.EventHandlers
{
    public class ItemUpdatedEventHandler : INotificationHandler<EntityUpdatedEvent<Item>>
    {
        private readonly ILogger<ItemUpdatedEventHandler> _logger;

        public ItemUpdatedEventHandler(ILogger<ItemUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(EntityUpdatedEvent<Item> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entity {name} ({id}) has been updated successfully", nameof(Item), notification.Entity.Id);

            return Task.CompletedTask;
        }
    }
}
