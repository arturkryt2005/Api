using Bakasov.Core.Entities.Statuses;
using Bakasov.Core.Repositories.Statuses;
using Microsoft.AspNetCore.Mvc;


namespace Bakasov.Api.Controllers
{
    /// <summary>
    /// Class StatusController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]

    public class StatusController : ControllerBase
    {
        /// <summary>
        /// The status repository
        /// </summary>
        private readonly IStatusRepository _statusRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusController" /> class.
        /// </summary>
        /// <param name="statusRepository">The status repository.</param>
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }


        /// <summary>
        /// Gets the statuses.
        /// </summary>
        /// <returns>List&lt;Status&gt;.</returns>
        [HttpGet]
        public async Task<List<Status>> GetStatuses()
        {
            return await _statusRepository.GetListAsync();
        }

        /// <summary>
        /// Adds the status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> AddStatus([FromBody] Status status)
        {
            try
            {
                await _statusRepository.AddAsync(status);
                return Ok(status);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deletes the status.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var result = await _statusRepository.DeleteAsync(id);
            return Ok(result ? $"Статус с id = {id} удален." : $"Удаляемый статус с id = {id} не найден.");
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStatus([FromBody] Status status)
        {
            var result = await _statusRepository.UpdateAsync(status);
            return Ok(result ? $"Размер с id = {status.Id} обновлен." : $"Размер с id =  {status.Id} не найден.");
        }
    }
}
