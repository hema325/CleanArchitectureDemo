using Domain.Common.Events;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Items.EventHandlers
{
    public class ItemDeletedEventHandler : INotificationHandler<EntityDeletedEvent<Item>>
    {
        private readonly ILogger<ItemDeletedEventHandler> _logger;

        public ItemDeletedEventHandler(ILogger<ItemDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(EntityDeletedEvent<Item> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entity {name} ({id}) has been deleted successfully", nameof(Item), notification.Entity.Id);

            return Task.CompletedTask;
        }
    }
}
