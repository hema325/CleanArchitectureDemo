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
    public class ItemCreatedEventHandler : INotificationHandler<ItemCreatedEvent>
    {
        private readonly ILogger<ItemCreatedEventHandler> _logger;

        public ItemCreatedEventHandler(ILogger<ItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entity {nameof(Item)} ({notification.Item.Name}) has been created successfully");

            return Task.CompletedTask;
        }
    }
}
