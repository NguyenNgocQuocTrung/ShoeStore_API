using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class OrderItemsDto
    {
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public long Price { get; set; }
    }
}