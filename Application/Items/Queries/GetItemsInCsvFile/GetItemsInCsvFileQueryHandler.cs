using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemsInCsvFile
{
    internal class GetItemsInCsvFileQueryHandler : IRequestHandler<GetItemsInCsvFileQuery, GetItemsInCsvFileResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder<ItemBriefDTO> _csvFileBuilder;
        private readonly IDateTime _dateTime;

        public GetItemsInCsvFileQueryHandler(IApplicationDbContext context,IMapper mapper, ICsvFileBuilder<ItemBriefDTO> csvFileBuilder,IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _csvFileBuilder = csvFileBuilder;
            _dateTime = dateTime;
        }

        public async Task<GetItemsInCsvFileResponse> Handle(GetItemsInCsvFileQuery request, CancellationToken cancellationToken)
        {
            var items = await _context.Items.ProjectTo<ItemBriefDTO>(_mapper.ConfigurationProvider).ToListAsync();

            var fileName = $"{_dateTime.Now}-Items";
            var fileContentType = "text/csv";
            var fileContent = await _csvFileBuilder.BuildAsync(items);

            var vm = new GetItemsInCsvFileResponse
            {
                FileName = fileName,
                ContentType = fileContentType,
                Content = fileContent
            };

            return vm;
        }
    }
}
