using Application.Common.Exceptions;
using Application.Common.Interfaces.Data;
using Application.Common.Interfaces.Repositories;
using Application.Items.Specifications;
using AutoMapper;
using Domain.Common.Events;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Commands.UpdateItem
{
    internal class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<Unit> IRequestHandler<UpdateItemCommand, Unit>.Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = (await _unitOfWork.Items.GetBySpecificationAsync(new GetItemByIdSpecification(request.Id)))
                .FirstOrDefault();

            if (item == null)
                throw new NotFoundException(nameof(Item), new { Id = request.Id });

            item.Name = Name.Create(request.Name);

            item.AddDomainEvent(new EntityUpdatedEvent<Item>(item));

            _unitOfWork.Items.Update(item);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
