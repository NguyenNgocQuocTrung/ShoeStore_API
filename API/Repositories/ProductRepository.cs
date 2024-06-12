using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Params;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace API.Repositories
{
    public class ProductRepository: BaseRepositories<Product>, IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(string sortBy)
        {
            var query = _context.Products.AsQueryable();

            query = sortBy switch
            {
                "priceDesc" => query.OrderByDescending(p => p.Price),
                "price" => query.OrderBy(p => p.Price),
                "name" => query.OrderBy(p => p.Name),
                "nameDesc" => query.OrderByDescending(p => p.Name), _ => query.OrderBy(p => p.Id)
            };

            return await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                PictureUrl = p.PictureUrl,
                Brand = p.Brand,
                Type = p.Type,
                QuantityInStock = p.QuantityInStock
            }).ToListAsync();
        }

       public async Task<PagedList<ProductDto>> GetProductsPagingAsync(ProductParams productParams)
{
    var query = _context.Products.AsQueryable();

    // Áp dụng bộ lọc
    if (!string.IsNullOrEmpty(productParams.Brand))
    {
        query = query.Where(p => p.Brand == productParams.Brand);
    }

    if (!string.IsNullOrEmpty(productParams.Type))
    {
        query = query.Where(p => p.Type == productParams.Type);
    }

    // Áp dụng sắp xếp
    query = productParams.Sort switch
    {
        "priceDesc" => query.OrderByDescending(p => p.Price),
        "price" => query.OrderBy(p => p.Price),
        "name" => query.OrderBy(p => p.Name),
        "nameDesc" => query.OrderByDescending(p => p.Name),
        _ => query.OrderBy(p => p.Id)
    };

    var count = await query.CountAsync();
    var items = await query
        .Skip((productParams.PageNumber - 1) * productParams.PageSize)
        .Take(productParams.PageSize)
        .Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            PictureUrl = p.PictureUrl,
            Brand = p.Brand,
            Type = p.Type,
            QuantityInStock = p.QuantityInStock
        })
        .ToListAsync();

    return new PagedList<ProductDto>(items, count, productParams.PageNumber, productParams.PageSize);
}

    }
}