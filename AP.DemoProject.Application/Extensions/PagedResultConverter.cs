using AP.BTP.Application;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.DemoProject.Application.Extensions {
    public static class PagedResultConverter {
        public static PagedResult<TDestination> ConvertPagedResult<TSource, TDestination>(this IMapper mapper, PagedResult<TSource> source) {
            return new PagedResult<TDestination>() {
                Data = mapper.Map<List<TDestination>>(source.Data),
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalNumberOfPages = source.TotalNumberOfPages,
                TotalRecordCount = source.TotalRecordCount,
                FilteredRecordCount = source.FilteredRecordCount
            };
        }
    }
}
