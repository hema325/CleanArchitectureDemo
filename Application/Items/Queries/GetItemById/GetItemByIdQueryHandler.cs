using Application.Common.Exceptions;
using Application.Common.Interfaces.Caching;
using Application.Common.Interfaces.Data;

namespace Application.Items.Queries.GetItemById
{
    internal class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, GetItemByIdDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;

        public GetItemByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ICacheService cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<GetItemByIdDTO> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            //caching here is just for testing we should use caching only with expensive queries that is needed frequently
            var key = $"Item-{request.Id}";
            var item = await _cache.GetAsync<GetItemByIdDTO>(key);

            if (item == null)
            {
                item = await _context.Items.ProjectTo<GetItemByIdDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(i => i.Id == request.Id);

                if (item == null)
                    throw new NotFoundException(nameof(item), request.Id);

                await _cache.SetAsync(key,item);
            }

            return item;
        }
    }
}
