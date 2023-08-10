using Application.Common.Exceptions;
using Application.Common.Interfaces.Data;
using Application.Common.Interfaces.Repositories;
using Application.Items.Specifications;
using Domain.Common.Events;
using Domain.Entities;

namespace Application.Items.Commands.DeleteItem
{
    internal class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteItemCommandHandler(IApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        async Task<Unit> IRequestHandler<DeleteItemCommand, Unit>.Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var item = (await _unitOfWork.Items.GetBySpecificationAsync(new GetItemByIdSpecification(request.Id)))
                .FirstOrDefault();

            if (item == null)
                throw new NotFoundException(nameof(Item), new { Id = request.Id });

            item.AddDomainEvent(new EntityDeletedEvent<Item>(item));

            _unitOfWork.Items.Delete(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
