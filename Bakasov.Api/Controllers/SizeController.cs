using Bakasov.Core.Entities.Sizes;
using Bakasov.Core.Repositories.Sizes;
using Microsoft.AspNetCore.Mvc;

namespace Bakasov.Api.Controllers
{
    /// <summary>
    /// Class SizeController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class SizeController : ControllerBase
    {
        /// <summary>
        /// The size repository
        /// </summary>
        private readonly ISizeRepository _sizeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SizeController" /> class.
        /// </summary>
        /// <param name="sizeRepository">The size repository.</param>
        public SizeController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }


        /// <summary>
        /// Gets the sizes.
        /// </summary>
        /// <returns>List&lt;Size&gt;.</returns>
        [HttpGet]
        public async Task<List<Size>> GetSizes()
        {
            return await _sizeRepository.GetListAsync();
        }

        /// <summary>
        /// Adds the size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> AddSize([FromBody] Size size)
        {
            try
            {
                await _sizeRepository.AddAsync(size);
                return Ok(size);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deletes the size.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            var result = await _sizeRepository.DeleteAsync(id);
            return Ok(result ? $"Размер с id = {id} удален." : $"Удаляемый размер с id = {id} не найден.");
        }

        /// <summary>
        /// Updates the size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateSize([FromBody] Size size)
        {
            var result = await _sizeRepository.UpdateAsync(size);
            return Ok(result ? $"Размер с id = {size.Id} обновлен." : $"Размер с id =  {size.Id} не найден.");
        }
    }
}
