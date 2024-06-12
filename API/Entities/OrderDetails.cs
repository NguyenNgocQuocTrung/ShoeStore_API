using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Common;

namespace API.Entities
{
    public class OrderDetails: BaseModels
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }

        [ForeignKey("ProductId")]
        public Product Products { get; set; }

    }
}