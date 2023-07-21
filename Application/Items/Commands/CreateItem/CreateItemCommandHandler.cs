using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events.ItemEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = request.Name
            };

            item.AddDomainEvent(new ItemCreatedEvent(item));

            _context.Items.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            return item.Id;
        }
    }
}
