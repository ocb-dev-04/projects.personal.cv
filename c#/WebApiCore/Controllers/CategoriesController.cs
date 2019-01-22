using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelCore.Entities;
using ModelCore.Interfaces;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : DIController
    {
        #region Properties

        private readonly ICategoriesRepository _categoriesRepository;

        #endregion

        #region Contruct

        public CategoriesController(
            ICategoriesRepository categoriesRepository,
            ILogger<CategoriesController> logger) : base(logger)
        => _categoriesRepository = categoriesRepository;

        #endregion

        #region GetAll GetById

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetAllCategories()
        {
            _logger.LogWarning("Acces to all categories");
            var response = await _categoriesRepository.GetAllCategoriesAsync();
            if (response == null)
            {
                _logger.LogWarning("Some error ocurred");
                return NotFound();
            }

            _logger.LogInformation("All categories was show");
            return Ok(response);
        }
        
        [HttpGet("{id}", Name = "categoriesCreated")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            _logger.LogInformation($"Acces to category with ID: {id}");
            var response = await _categoriesRepository.GetCategoryById(id);
            if (response == null)
            {
                _logger.LogWarning("Some error ocurred");
                return NotFound();
            }

            _logger.LogInformation($"Category with ID: {id} showed");
            return Ok(response);
        }

        #endregion

        #region CRUD
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Categories create)
        {
            _logger.LogInformation($"Try CREATE a new category with: {create}");
            if(ModelState.IsValid)
            {
                var response = await _categoriesRepository.CreateCategoryAsync(create);
                if(response == null)
                {
                    _logger.LogWarning("Some error ocurred while create the new category");
                    return NotFound();
                }

                _logger.LogInformation("Category created succesful");
                return new CreatedAtRouteResult("categoriesCreated", new { id = response.Id }, response);
            }

            _logger.LogWarning("ModelState invalid");
            return BadRequest(ModelState);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Categories update)
        {
            _logger.LogInformation($"Try to UPDATE Category with id {id} and info is: {update}");
            if(ModelState.IsValid && id == update.Id)
            {
                await _categoriesRepository.UpdateCategoryAsync(id, update);
                return NoContent();
            }

            _logger.LogWarning("ModelSate is invalid or id is wrong");
            return BadRequest(ModelState);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            _logger.LogInformation($"Try to DELETE category with ID: {id}");
            await _categoriesRepository.DeleteCategoryAsync(id);
            _logger.LogInformation("Category with Id: {0} deleted", id);
            return NoContent();
        }

        #endregion
    }
}
