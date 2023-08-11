using Application.Common.Models;

namespace Application.Items.Queries.GetItemsWithPagination
{
    public sealed record GetItemsWithPaginationQuery(int PageNumber, int PageSize): IRequest<PaginatedList<GetItemWithPaginationDTO>>;
}
