using Bakasov.Core.Entities.Brands;
using Bakasov.Core.Repositories.Brands;
using Microsoft.AspNetCore.Mvc;

namespace Bakasov.Api.Controllers
{
    /// <summary>
    /// Class BrandController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]

    public class BrandController : ControllerBase
    {
        /// <summary>
        /// The brand repository
        /// </summary>
        private readonly IBrandRepository _brandRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandController" /> class.
        /// </summary>
        /// <param name="brandRepository">The brand repository.</param>
        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        /// <summary>
        /// Gets the brands.
        /// </summary>
        /// <returns>List&lt;Brand&gt;.</returns>
        [HttpGet]
        public async Task<List<Brand>> GetBrands()
        {
            return await _brandRepository.GetListAsync();
        }

        /// <summary>
        /// Adds the brand.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Brand brand)
        {
            try
            {
                await _brandRepository.AddAsync(brand);
                return Ok(brand);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deletes the brand.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var result = await _brandRepository.DeleteAsync(id);
            return Ok(result ? $"Бренд с id = {id} удален." : $"Удаляемый бренд с id = {id} не найден.");
        }

        /// <summary>
        /// Updates the brand.
        /// </summary>
        /// <param name="brand">The brand.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] Brand brand)
        {
            var result = await _brandRepository.UpdateAsync(brand);
            return Ok(result ? $"Бренд с id = {brand.Id} обновлен." : $"Бренд с id = {brand.Id} не найден.");
        }
    }
}
