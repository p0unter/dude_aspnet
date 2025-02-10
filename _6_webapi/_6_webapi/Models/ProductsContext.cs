using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _6_webapi.Models;

public class ProductsContext : IdentityDbContext<AppUser, AppRole, int>
{
    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(new Product()
            { ProductId = 1, ProductName = "Iphone 8", Price = 2000, IsActive = true }
        );
        modelBuilder.Entity<Product>().HasData(new Product()
            { ProductId = 2, ProductName = "Iphone 9", Price = 3000, IsActive = true }
        );
        modelBuilder.Entity<Product>().HasData(new Product()
            { ProductId = 3, ProductName = "Iphone 10", Price = 4000, IsActive = false }
        );
        modelBuilder.Entity<Product>().HasData(new Product()
            { ProductId = 4, ProductName = "Iphone 11", Price = 5000, IsActive = true }
        );
    }

    public DbSet<Product> Products { get; set; } 
}