using Application.Common.Interfaces.Data;
using Application.Common.Interfaces.Services;
using Application.Items.Queries.GetItemsWithPagination;

namespace Application.Items.Queries.GetItemsInCsvFile
{
    internal class GetItemsInCsvFileQueryHandler : IRequestHandler<GetItemsInCsvFileQuery, GetItemsInCsvFileDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder<GetItemWithPaginationDTO> _csvFileBuilder;
        private readonly IDateTime _dateTime;

        public GetItemsInCsvFileQueryHandler(IApplicationDbContext context,IMapper mapper, ICsvFileBuilder<GetItemWithPaginationDTO> csvFileBuilder,IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _csvFileBuilder = csvFileBuilder;
            _dateTime = dateTime;
        }

        public async Task<GetItemsInCsvFileDTO> Handle(GetItemsInCsvFileQuery request, CancellationToken cancellationToken)
        {
            var items = await _context.Items.ProjectTo<GetItemWithPaginationDTO>(_mapper.ConfigurationProvider).ToListAsync();

            var fileName = $"{_dateTime.Now}-Items";
            var fileContentType = "text/csv";
            var fileContent = await _csvFileBuilder.BuildAsync(items);

            var dto = new GetItemsInCsvFileDTO
            {
                FileName = fileName,
                ContentType = fileContentType,
                Content = fileContent
            };

            return dto;
        }
    }
}
