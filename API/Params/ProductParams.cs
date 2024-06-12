using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common;

namespace API.Params
{
    public class ProductParams : BaseParams
    {
         public string? Brand { get; set; }
    public string? Type { get; set; }

    }
}