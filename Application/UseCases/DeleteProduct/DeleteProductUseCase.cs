using Application.Database.Repository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteProduct
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<DeleteProductUseCase> _logger;

        public DeleteProductUseCase(IProductRepository productRepository, ILogger<DeleteProductUseCase> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync(int id)
        {
            await _productRepository.DeleteProduct(id);
            _logger.LogInformation("O produto de Id {id} foi deletado com sucesso", id);
        }
    }
}
