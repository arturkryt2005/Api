using Bakasov.Core.Entities.Categories;
using Bakasov.Core.Repositories.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Bakasov.Api.Controllers
{
    /// <summary>
    /// Class UserController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// The category repository
        /// </summary>
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController" /> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>List&lt;Category&gt;.</returns>
        [HttpGet]
        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.GetListAsync();
        }

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteAsync(id);
            return Ok(result ? $"Категория с id = {id} удалена." : $"Удаляемая категория с id = {id} не найдена.");
        }

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            var result = await _categoryRepository.UpdateAsync(category);
            return Ok(result ? $"Категория с id = {category.Id} обновлена." : $"Категория с id = {category.Id} не найдена.");
        }
    }
}
