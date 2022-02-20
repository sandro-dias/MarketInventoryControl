using Application.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public ProductContext() {}
    }
}
