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
    public class ItemCreatedEventHandler : INotificationHandler<EntityCreatedEvent<Item>> 
    {
        private readonly ILogger<ItemCreatedEventHandler> _logger;

        public ItemCreatedEventHandler(ILogger<ItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(EntityCreatedEvent<Item> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entity {name} ({id}) has been created successfully,",nameof(Item));

            return Task.CompletedTask;
        }
    }
}
