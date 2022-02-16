using Application.UseCases.ValidateProduct;
using Application.UseCases.ValidateProduct.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class MarketInventoryController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IValidateProductUseCase _useCase;

        public MarketInventoryController(ILogger logger, IValidateProductUseCase useCase)
        {
            _logger = logger;
            _useCase = useCase;
        }

        [HttpGet]
        [Route("api/get-product")]
        public void GetProduct()
        {
            //TO-DO: avaliar os parâmetros de entrada            
        }

        [HttpPost]
        [Route("api/post-product")]
        public async Task PostProduct([FromBody] ValidateProductInput input)
        {       
            try
            {
                await _useCase.ExecuteAsync(input);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Não foi possível inserir o produto no banco de dados. A seguinte messagem foi retornada: {Message}", ex.Message);
                throw new Exception();
            }
        }
    }
}
