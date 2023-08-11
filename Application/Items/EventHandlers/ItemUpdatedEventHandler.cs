using Domain.Common.Events;
using Domain.Entities;
using Microsoft.Extensions.Logging;

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
