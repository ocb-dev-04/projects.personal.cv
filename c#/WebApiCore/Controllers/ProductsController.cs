using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelCore.Entities;
using ModelCore.Interfaces;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories/{categoryId}/Products")]
    [ApiController]
    public class ProductsController : DIController
    {
        #region Properties

        private readonly IProductsRepository _productsRepository;

        #endregion

        #region Construct

        public ProductsController(
            IProductsRepository productsRepository,
            ILogger<ProductsController> logger) : base(logger)
                => _productsRepository = productsRepository;

        #endregion

        #region GetAll GetById

        [HttpGet]
        public async Task<IEnumerable<Products>> GetAllProducts(int categoryId)
        {
            _logger.LogInformation("Acces to all products");
            return await _productsRepository.GetAllProductsAsync(categoryId);
        }
        
        [HttpGet("{id}", Name = "productCreated")]
        public async Task<IActionResult> GetProductById(int id)
        {
            _logger.LogInformation("Get for product with ID -----> {0}", id);
            var response = await _productsRepository.GetProductById(id);
            if (response == null)
            {
                _logger.LogInformation("Product with ID -----> {0} not found!", id);
                return NotFound();
            }

            _logger.LogInformation("Product found succesful!");
            return Ok(response);
        }

        #endregion

        #region CRUD
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(int categoryId, [FromBody] Products create)
        {
            _logger.LogWarning($"Try to CREATE a new product: {create.Name} with CategoryId: {categoryId}");
            if (ModelState.IsValid)
            {
                create.CategoryId = categoryId;
                var response = await _productsRepository.CreateProductAsync(create);
                if (response == null)
                {
                    _logger.LogWarning("Some error ocurred while create the products");
                    return NotFound();
                }

                _logger.LogWarning($"Product {response.Name} create succesful");
                return new CreatedAtRouteResult("productCreated", new { id= response.Id }, response);
            }

            _logger.LogWarning("Modeltate invalid");
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Products update)
        {
            if(ModelState.IsValid && id == update.Id)
            {
                _logger.LogInformation($"Try UPDATE a product: {update.Name}");
                await _productsRepository.UpdateProductAsync(id, update);
                _logger.LogInformation($"Product {update.Name} update succesful");
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            _logger.LogInformation($"Try to DELETE product with ID: {id}");
            await _productsRepository.DeleteProductAsync(id);
            _logger.LogInformation("Product delete succesful");
            return NoContent();
        }
        
        #endregion
    }
}
