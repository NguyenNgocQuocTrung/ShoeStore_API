using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : IdentityDbContext<Users>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Member", NormalizedName = "MEMBER" }
            );

            //thiết lập khóa ngoại UserId bảng Orders tới khóa chính Id bảng Users
            builder.Entity<Orders>()
            .HasOne(o => o.User) //User từ thuộc tính của Orders
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        // Thiết lập mối quan hệ giữa Orders và OrderItems
        builder.Entity<OrderItems>()
            .HasOne(oi => oi.Orders)
            .WithMany(o => o.OrderItem)
            .HasForeignKey(oi => oi.OrderId);
        }

    }
}