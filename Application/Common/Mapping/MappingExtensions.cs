using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    public static class MappingExtensions
    {
        public static async Task<PaginatedList<TDestination>> PaginateAsync<TDestination>(this IQueryable<TDestination> source, int pageNumber, int pageSize) where TDestination : class
        {
            var totalCount = await source.CountAsync();
            var items = await source.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<TDestination>(items, totalCount, pageNumber, pageSize);
        }
            
    }
}
