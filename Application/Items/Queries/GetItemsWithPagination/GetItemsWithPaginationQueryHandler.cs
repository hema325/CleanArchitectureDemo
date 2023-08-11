using Application.Common.Extensions;
using Application.Common.Interfaces.Data;
using Application.Common.Models;

namespace Application.Items.Queries.GetItemsWithPagination
{
    internal class GetItemsWithPaginationQueryHandler : IRequestHandler<GetItemsWithPaginationQuery,PaginatedList<GetItemWithPaginationDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemsWithPaginationQueryHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetItemWithPaginationDTO>> Handle(GetItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Items.ProjectTo<GetItemWithPaginationDTO>(_mapper.ConfigurationProvider).PaginateAsync(request.PageNumber, request.PageSize);
        }
    }
}
