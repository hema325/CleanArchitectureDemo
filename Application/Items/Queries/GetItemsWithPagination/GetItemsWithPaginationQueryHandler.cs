using Application.Common.Interfaces;
using Application.Common.Mapping;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemsWithPagination
{
    internal class GetItemsWithPaginationQueryHandler : IRequestHandler<GetItemsWithPaginationQuery,PaginatedList<ItemBriefDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemsWithPaginationQueryHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ItemBriefDTO>> Handle(GetItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Items.ProjectTo<ItemBriefDTO>(_mapper.ConfigurationProvider).PaginateAsync(request.PageNumber, request.PageSize);
        }
    }
}
