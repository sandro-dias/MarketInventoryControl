using Application.Database.Entities;
using Application.Database.Repository;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }        

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            return product;
        }

        public async Task<Product> InsertProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
