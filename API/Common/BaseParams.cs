using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common
{
    public class BaseParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;

       public string? Sort { get; set; }

       
    }
}