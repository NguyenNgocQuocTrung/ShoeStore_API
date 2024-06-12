using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Common;

namespace API.Entities
{
    public class OrderItems : BaseModels
    {
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }

    public Orders Orders { get; set; }
    public long Price { get; set; }

    }
}