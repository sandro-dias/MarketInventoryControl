using Application.UseCases.ValidateProduct.Input;
using System.Threading.Tasks;

namespace Application.UseCases.ValidateProduct
{
    public interface IValidateProductUseCase
    {
        Task ExecuteAsync(ValidateProductInput input);
    }
}
