using Application.Database.Entities;
using Application.Database.Repository;
using Application.UseCases.ValidateProduct.Input;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.UseCases.PutProduct
{
    public class PutProductUseCase : IPutProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<PutProductUseCase> _logger;
        private readonly IValidator<ValidateProductInput> _validator;        

        public PutProductUseCase(IProductRepository productRepository, ILogger<PutProductUseCase> logger, IValidator<ValidateProductInput> validator)
        {
            _productRepository = productRepository;
            _logger = logger;
            _validator = validator;
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

            await _productRepository.UpdateProduct(product);
            _logger.LogInformation("O produto de Id {id} foi atualizado com sucesso", input.Id);            
        }
    }
}
