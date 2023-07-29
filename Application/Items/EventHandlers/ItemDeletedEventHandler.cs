using Domain.Common.Entities;
using Domain.Common.Events;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Items.EventHandlers
{
    public class ItemDeletedEventHandler : INotificationHandler<DeletedEvent<Item>>
    {
        private readonly ILogger<ItemDeletedEventHandler> _logger;

        public ItemDeletedEventHandler(ILogger<ItemDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DeletedEvent<Item> notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entity {0} ({1}) has been deleted successfully", nameof(Item), notification.Entity.Id);

            return Task.CompletedTask;
        }
    }
}
