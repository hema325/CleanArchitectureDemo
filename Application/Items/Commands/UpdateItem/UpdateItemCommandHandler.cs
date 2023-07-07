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
    internal class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.Id);

            if (item == null)
                throw new NotFoundException(nameof(Item), new { Id = request.Id });

            _mapper.Map(request, item);

            item.AddDomainEvent(new ItemUpdatedEvent(item));

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
