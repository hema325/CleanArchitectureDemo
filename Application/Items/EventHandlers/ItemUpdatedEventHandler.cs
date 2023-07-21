using Domain.Entities;
using Domain.Events.ItemEvents;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.EventHandlers
{
    public class ItemUpdatedEventHandler: INotificationHandler<ItemUpdatedEvent>
    {
        private readonly ILogger<ItemUpdatedEventHandler> _logger;

        public ItemUpdatedEventHandler(ILogger<ItemUpdatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ItemUpdatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entity {nameof(Item)} ({notification.Item.Id}) has been updated successfully");

            return Task.CompletedTask;
        }
    }
}
