using System.Collections.Generic;

namespace AP.BTP.BlazorClient.Models
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalRecordCount { get; set; }
        public int FilteredRecordCount { get; set; }
    }
}