using Application.Common.Models;
using Application.Common.Specifications;
using Domain.Common;

namespace Application.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static async Task<PaginatedList<TDestination>> PaginateAsync<TDestination>(this IQueryable<TDestination> source, int pageNumber, int pageSize) where TDestination : class
        {
            var totalCount = await source.CountAsync();
            var items = await source.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TDestination>(items, totalCount, pageNumber, pageSize);
        }

    }
}
