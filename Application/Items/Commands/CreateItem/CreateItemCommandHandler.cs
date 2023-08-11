using Application.Common.Interfaces.FilesStorage;
using Application.Common.Interfaces.Repositories;
using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Items.Commands.CreateItem
{
    internal class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorage _fileStorage;

        public CreateItemCommandHandler(IUnitOfWork unitOfWork, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Item
            {
                Name = Name.Create(request.Name),
                ImagePath = await _fileStorage.SaveAsync(request.Image)
            };

            item.AddDomainEvent(new EntityCreatedEvent<Item>(item));

            await _unitOfWork.Items.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return item.Id;
        }
    }
}
