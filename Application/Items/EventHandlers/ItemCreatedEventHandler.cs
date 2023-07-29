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
    public class ItemCreatedEventHandler : INotificationHandler<CreatedEvent<Item>> 
    {
        private readonly ILogger<ItemCreatedEventHandler> _logger;

        public ItemCreatedEventHandler(ILogger<ItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CreatedEvent<Item> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entity {0} ({1}) has been created successfully",nameof(Item), notification.Entity.Id);

            return Task.CompletedTask;
        }
    }
}
