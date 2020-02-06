using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class PagingInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)ItemCount / PageSize);

    }
}
