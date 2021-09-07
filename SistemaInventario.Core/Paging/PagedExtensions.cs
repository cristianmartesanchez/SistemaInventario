using AutoMapper.QueryableExtensions;
using System;
using System.Linq;

namespace SistemaInventario.Core.Paging
{
    public static class PagedExtensions
    {
        public static PagedResult<T> Paged<T>(this IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page + 1,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = page * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public static PagedResult<TMap> Paged<T, TMap>(this IQueryable<T> query,
                                            int page, int pageSize) where TMap : class
        {
            var result = new PagedResult<TMap>
            {
                CurrentPage = page + 1,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = page * pageSize;
            //result.Results = query.Skip(skip)
            //                      .Take(pageSize)
            //                      //.ProjectTo<TMap>()
            //                      .ToList();

            return result;
        }
    }
}
