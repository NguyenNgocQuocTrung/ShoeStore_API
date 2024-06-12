using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrdersController: BaseController
    {
        
        private readonly IOrdersRepository _ordersRepository;

            private readonly UserManager<Users> _userManager;
        public OrdersController(IOrdersRepository ordersRepository, UserManager<Users> userManager)
        {
            _ordersRepository = ordersRepository;
            _userManager = userManager;
        }

        //viết hàm thêm mới đơn hàng
       [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder(OrdersDto ordersDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return Unauthorized();
            }

            var order = new Orders
            {
                UserId = user.Id,
                OrderItem = ordersDto.OrderItems.Select(oi => new OrderItems
                {              
                    Quantity = oi.Quantity,
                    ProductId = oi.ProductId,
                    Price = oi.Price * oi.Quantity
                }).ToList()
            };

            var result = await _ordersRepository.AddAsync(order);
            return Ok(result);
        }
        
    }
}