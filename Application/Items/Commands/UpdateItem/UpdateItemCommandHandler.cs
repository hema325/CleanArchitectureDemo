using Application.Common.Exceptions;
using Application.Common.Interfaces.Data;
using Application.Common.Interfaces.Repositories;
using Application.Items.Specifications;
using AutoMapper;
using Domain.Common.Events;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateItemCommandHandler(IApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        async Task<Unit> IRequestHandler<UpdateItemCommand, Unit>.Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = (await _unitOfWork.Items.GetBySpecificationAsync(new GetItemByIdSpecification(request.Id)))
                .FirstOrDefault();

            if (item == null)
                throw new NotFoundException(nameof(Item), new { Id = request.Id });

            item.Name = request.Name;

            item.AddDomainEvent(new UpdatedEvent<Item>(item));

            _unitOfWork.Items.Update(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
