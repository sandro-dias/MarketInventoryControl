using Application.Database.Entities;
using Application.UseCases.DeleteProduct;
using Application.UseCases.GetProduct;
using Application.UseCases.PutProduct;
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
        private readonly ILogger<MarketInventoryController> _logger;
        private readonly IPostProductUseCase _postProductUseCase;
        private readonly IGetProductUseCase _getProductUseCase;
        private readonly IPutProductUseCase _putProductUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;

        public MarketInventoryController(ILogger<MarketInventoryController> logger, 
                                         IPostProductUseCase postProductUseCase, 
                                         IGetProductUseCase getProductUseCase, 
                                         IPutProductUseCase putProductUseCase, 
                                         IDeleteProductUseCase deleteProductUseCase)
        {
            _logger = logger;
            _postProductUseCase = postProductUseCase;
            _getProductUseCase = getProductUseCase;
            _putProductUseCase = putProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
        }

        [HttpGet]
        [Route("api/get-product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {            
            try
            {
                var product = await _getProductUseCase.ExecuteAsync(id);
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível encontrar o produto no banco de dados. A seguinte messagem foi retornada: {Message}", ex.Message);
                throw new Exception();
            }           
        }

        [HttpPost]
        [Route("api/post-product")]
        
        public async Task<IActionResult> PostProduct([FromBody] ValidateProductInput input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _postProductUseCase.ExecuteAsync(input);
                return Ok(input);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível inserir o produto no banco de dados. A seguinte messagem foi retornada: {Message}", ex.Message);
                throw new Exception();
            }
        }

        [HttpPut]
        [Route("api/update-product/{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] ValidateProductInput input)
        {
            if (id != input.Id)
                return BadRequest(new { message = "Id informado está incorreto" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _putProductUseCase.ExecuteAsync(input);
                return Ok(input);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível atualizar o produto no banco de dados. A seguinte messagem foi retornada: {Message}", ex.Message);
                throw new Exception();
            }
        }

        [HttpDelete]
        [Route("api/delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _deleteProductUseCase.ExecuteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível deletar o produto no banco de dados. A seguinte messagem foi retornada: {Message}", ex.Message);
                throw new Exception();
            }
        }
    }
}
