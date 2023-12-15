using Bakasov.Core.Entities.OrderProducts;
using Bakasov.Core.Repositories.OrderProducts;
using Microsoft.AspNetCore.Mvc;

namespace Bakasov.Api.Controllers
{
    /// <summary>
    /// Class OrderProductController.
    /// Implements the <see cref="ControllerBase" />
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]

    public class OrderProductController : Controller
    {

        /// <summary>
        /// The OrderProduct repository
        /// </summary>
        private readonly IOrderProductRepository _orderProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProductController" /> class.
        /// </summary>
        /// <param name="orderProductRepository">The orderProduct repository.</param>
        public OrderProductController(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }


        /// <summary>
        /// Gets the orderProducts.
        /// </summary>
        /// <returns>List&lt;OrderProduct&gt;.</returns>
        [HttpGet]
        public async Task<List<OrderProduct>> GetOrderProducts()
        {
            return await _orderProductRepository.GetListAsync();
        }

        /// <summary>
        /// Adds the orderProduct.
        /// </summary>
        /// <param name="orderProduct">The orderProduct.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> AddOrderProduct([FromBody] OrderProduct orderProduct)
        {
            try
            {
                await _orderProductRepository.AddAsync(orderProduct);
                return Ok(orderProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deletes the orderProduct.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrderProduct(int id)
        {
            var result = await _orderProductRepository.DeleteAsync(id);
            return Ok(result ? $"Обьект с id = {id} удален." : $"Обьект с id = {id} не найден.");
        }

        /// <summary>
        /// Updates the orderProduct.
        /// </summary>
        /// <param name="orderProduct">The orderProduct.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrderProduct([FromBody] OrderProduct orderProduct)
        {
            var result = await _orderProductRepository.UpdateAsync(orderProduct);
            return Ok(result ? $"Обьект с id = {orderProduct.Id} обновлен." : $"Размер с id =  {orderProduct.Id} не найден.");
        }
    }
}
