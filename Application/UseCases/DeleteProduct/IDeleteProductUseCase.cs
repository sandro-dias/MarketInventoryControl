using System.Threading.Tasks;

namespace Application.UseCases.DeleteProduct
{
    public interface IDeleteProductUseCase
    {
        Task ExecuteAsync(int id);
    }
}
