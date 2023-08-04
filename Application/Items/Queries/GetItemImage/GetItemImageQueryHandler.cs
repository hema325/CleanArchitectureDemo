using Application.Common.Exceptions;
using Application.Common.Helpers;
using Application.Common.Interfaces.Data;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemImage
{
    internal class GetItemImageQueryHandler : IRequestHandler<GetItemImageQuery,FileDTO>
    {
        private readonly IApplicationDbContext _context;

        public GetItemImageQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FileDTO> Handle(GetItemImageQuery request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == request.ItemId);

            if (item == null)
                throw new NotFoundException(nameof(item), request.ItemId);

            var fileDTO =  new FileDTO
            {
                PhysicalPath = PathHelper.GetAbsolutePath(item.ImagePath),
                ContentType = "image/jpg",
                FileName = item.Name
            };

            return fileDTO;
        }
    }
}
