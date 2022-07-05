using System;
using System.Linq;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.Services.Helpers
{
    public class PagingHelper
    {
        public static PagingViewModel<T> Create<T>(IQueryable<T> query, int pageIndex = 1, int pageSize = 100)
        {
            int records = query.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            var items = query.Skip(excludedRows).Take(pageSize).ToList();
            return new PagingViewModel<T>() { PageIndex = pageIndex, PageSize = pageSize, Items = items, Records = records, Pages = pages };
        }
    }
}
