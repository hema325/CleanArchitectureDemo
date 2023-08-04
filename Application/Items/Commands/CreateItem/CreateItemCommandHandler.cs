using Application.Common.Interfaces.Data;
using Application.Common.Interfaces.FilesStorage;
using Application.Common.Interfaces.Repositories;
using Domain.Common.Events;
using Domain.Entities;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
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
                Name = request.Name,
                ImagePath = await _fileStorage.SaveAsync(request.Image)
            };

            item.AddDomainEvent(new CreatedEvent<Item>(item));

            await _unitOfWork.Items.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return item.Id;
        }
    }
}
