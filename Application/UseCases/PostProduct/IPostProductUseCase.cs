using Application.Database.Entities;
using Application.UseCases.ValidateProduct.Input;
using System.Threading.Tasks;

namespace Application.UseCases.ValidateProduct
{
    public interface IPostProductUseCase
    {
        Task ExecuteAsync(ValidateProductInput input);
    }
}
