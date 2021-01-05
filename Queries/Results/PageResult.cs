using Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Queries.ViewModels.Results
{
    public class PageResult<T> : RespResult
    {
        public int PageIndex { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
