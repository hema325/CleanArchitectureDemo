using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class PaginatedList<T>
    {
        public IReadOnlyList<T> Items { get; }

        public int TotalPages { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        internal PaginatedList(IReadOnlyList<T> items,int totalCount,int pageNumber,int pageSize)
        {
            Items = items;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
    }
}
