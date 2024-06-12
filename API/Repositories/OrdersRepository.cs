using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Repositories
{
    public class OrdersRepository : BaseRepositories<OrdersDto>, IOrdersRepository
    {
        private readonly StoreContext _context;
        public OrdersRepository(StoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
