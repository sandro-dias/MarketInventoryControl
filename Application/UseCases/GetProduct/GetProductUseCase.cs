using Application.Database.Entities;
using Application.Database.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetProduct
{
    public class GetProductUseCase : IGetProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductUseCase> _logger;

        public GetProductUseCase(IProductRepository productRepository, ILogger<GetProductUseCase> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Product> ExecuteAsync(int id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product is null)
            {
                _logger.LogInformation("O produto de Id {id} não foi encontrado", id);
                throw new Exception();
            }

            _logger.LogInformation("O produto de Id {id} foi recuperado com sucesso", id);

            return product;
        }
    }
}
