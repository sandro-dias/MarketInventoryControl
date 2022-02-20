using Application.Database.Entities;
using System.Threading.Tasks;

namespace Application.UseCases.GetProduct
{
    public interface IGetProductUseCase
    {
        Task<Product> ExecuteAsync(int id);
    }
}
