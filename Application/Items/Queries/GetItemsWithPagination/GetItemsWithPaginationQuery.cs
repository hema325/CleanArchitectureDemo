using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemsWithPagination
{
    public class GetItemsWithPaginationQuery: IRequest<PaginatedList<GetItemWithPaginationDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
