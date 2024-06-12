using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class OrdersDto
    {
    public int Id { get; set; }
    public string UserId { get; set; }
    public List<OrderItemsDto> OrderItems { get; set; }
}

}