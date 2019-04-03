using Microsoft.EntityFrameworkCore;
using Product.Persistence.Models;

namespace Product.Persistence.DBContexts
{
  public class ProductContext : DbContext
  {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }
    public DbSet<Products> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Products>().HasData(
          new Products
          {
            Id = 1,
            Name = "Electronics",
            Url = "El@dmil.com",
            Code = "1111",
          }
      );
    }

  }
}
