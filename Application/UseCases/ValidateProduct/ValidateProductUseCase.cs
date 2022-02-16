using Application.UseCases.ValidateProduct.Input;
using Application.UseCases.ValidateProduct.Validator;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.UseCases.ValidateProduct
{
    public class ValidateProductUseCase : IValidateProductUseCase
    {
        private readonly ValidateProductInputValidator _validator;
        private readonly PostProductService _postProductService;
        private readonly ILogger _logger;

        public ValidateProductUseCase(ValidateProductInputValidator validator, PostProductService postProductService, ILogger logger)
        {
            _validator = validator;
            _postProductService = postProductService;
            _logger = logger;
        }

        public Task ExecuteAsync(ValidateProductInput input)
        {
            var validationResult = _validator.Validate(input);

            if (!validationResult.IsValid)
            {
                _logger.LogError("");
            }
                

            _postProductService.InsertProduct(input);
            _logger.LogInformation("");
        }
    }
}
