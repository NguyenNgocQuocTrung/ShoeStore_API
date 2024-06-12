using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common;
using API.DTOs;
using API.Entities;
using API.Params;

namespace API.Interfaces
{
    public interface IProductRepository : IBaseRepositories<Product>
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync(string sortBy);
        Task<PagedList<ProductDto>> GetProductsPagingAsync(ProductParams productParams);
    }
}