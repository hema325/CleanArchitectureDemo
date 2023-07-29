using Application.Common.Interfaces.Data;
using Application.Common.Interfaces.Repositories;
using Domain.Common.Events;
using Domain.Entities;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CreateItemCommandHandler(IApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = request.Name
            };

            item.AddDomainEvent(new CreatedEvent<Item>(item));

            await _unitOfWork.Items.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return item.Id;
        }
    }
}
