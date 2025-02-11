using Microsoft.EntityFrameworkCore;

namespace _7_storepp.Data.Concrete;

public class StoreDbContext:DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Products)
            .UsingEntity<ProductCategory>();

        modelBuilder.Entity<Category>()
            .HasIndex(u => u.Url)
            .IsUnique();

        modelBuilder.Entity<Product>().HasData(
            new List<Product>() {}
        );

        modelBuilder.Entity<Category>().HasData(
            new List<Category>() {}
        );

        modelBuilder.Entity<ProductCategory>().HasData(
            new List<ProductCategory>() {
                new ProductCategory() { ProductId=1, CategoryId=1},
                new ProductCategory() { ProductId=1, CategoryId=2},
                new ProductCategory() { ProductId=2, CategoryId=1},
                new ProductCategory() { ProductId=3, CategoryId=1},
                new ProductCategory() { ProductId=4, CategoryId=1},
                new ProductCategory() { ProductId=5, CategoryId=2},
                new ProductCategory() { ProductId=6, CategoryId=2},
            }
        );

    }
}