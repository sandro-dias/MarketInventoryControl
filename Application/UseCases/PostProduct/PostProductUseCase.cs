using Application.Database.Entities;
using Application.Database.Repository;
using Application.UseCases.ValidateProduct.Input;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.UseCases.ValidateProduct
{
    public class PostProductUseCase : IPostProductUseCase
    {
        private readonly IValidator<ValidateProductInput> _validator;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<PostProductUseCase> _logger;

        public PostProductUseCase(IValidator<ValidateProductInput> validator, IProductRepository productRepository, ILogger<PostProductUseCase> logger)
        {
            _validator = validator;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync(ValidateProductInput input)
        {
            var validationResult = _validator.Validate(input);

            if (!validationResult.IsValid)
            {
                _logger.LogError("A validação do input retornou falha com o seguinte erro: {Errors}", validationResult.Errors);
                return;
            }

            var product = new Product(input.Id, input.Name, input.Brand, input.Price, input.Quantity);

            await _productRepository.InsertProduct(product);
            _logger.LogInformation("O produto de Id {id} foi inserido com sucesso", input.Id);
        }
    }
}
