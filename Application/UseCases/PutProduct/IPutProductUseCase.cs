using Application.Database.Entities;
using Application.UseCases.ValidateProduct.Input;
using System.Threading.Tasks;

namespace Application.UseCases.PutProduct
{
    public interface IPutProductUseCase
    {
        Task ExecuteAsync(ValidateProductInput product);
    }
}
