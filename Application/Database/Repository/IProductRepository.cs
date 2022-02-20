using Application.Database.Entities;
using System.Threading.Tasks;

namespace Application.Database.Repository
{
    public interface IProductRepository
    {
        Task<Product> InsertProduct(Product product);
        Task<Product> GetProduct(int id);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
