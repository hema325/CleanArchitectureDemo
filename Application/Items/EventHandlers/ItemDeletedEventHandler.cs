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
    public class ItemDeletedEventHandler: INotificationHandler<ItemDeletedEvent>
    {
        private readonly ILogger<ItemDeletedEventHandler> _logger;

        public ItemDeletedEventHandler(ILogger<ItemDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ItemDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Entity {nameof(Item)} ({notification.Item.Id}) has been deleted successfully");

            return Task.CompletedTask;
        }
    }
}
