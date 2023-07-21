using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Events.ItemEvents;
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

        public UpdateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async Task<Unit> IRequestHandler<UpdateItemCommand, Unit>.Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.Id);

            if (item == null)
                throw new NotFoundException(nameof(Item), new { Id = request.Id });

            item.Name = request.Name;

            item.AddDomainEvent(new ItemUpdatedEvent(item));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
