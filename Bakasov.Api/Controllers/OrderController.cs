using Bakasov.Core.Entities.Orders;
using Bakasov.Core.Repositories.Orders;
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
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// The order repository
        /// </summary>
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController" /> class.
        /// </summary>
        /// <param name="orderRepository">The order repository.</param>
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }



        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <returns>List&lt;Order&gt;.</returns>
        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetListAsync();
        }

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                await _orderRepository.AddAsync(order);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Deletes the order.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepository.DeleteAsync(id);
            return Ok(result ? $"Заказ с id = {id} удален." : $"Удаляемый заказ с id = {id} не найден.");
        }

        /// <summary>
        /// Updates the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns>IActionResult.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            var result = await _orderRepository.UpdateAsync(order);
            return Ok(result ? $"Заказ с id = {order.Id} обновлен." : $"Заказ с id = {order.Id} не найден.");
        }
    }
}
