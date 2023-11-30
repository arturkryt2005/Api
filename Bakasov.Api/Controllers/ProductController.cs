using Bakasov.Core.Entities;
using Bakasov.Core.Entities.Products;
using Bakasov.Core.Repositories.Products;
using Microsoft.AspNetCore.Mvc;

namespace Bakasov.Api.Controllers;
/// <summary>
/// Class ProductController.
/// Implements the <see cref="ControllerBase" />
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    /// <summary>
    /// The product repository
    /// </summary>
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductController" /> class.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// Gets the products.
    /// </summary>
    /// <returns>List&lt;Product&gt;.</returns>
    [HttpGet]
    public async Task<List<Product>> GetProducts()
    {
        return await _productRepository.GetListAsync();
    }

    /// <summary>
    /// Adds the product.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    /// <summary>
    /// Deletes the product.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>IActionResult.</returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productRepository.DeleteAsync(id);
        return Ok(result ? $"Объект с id = {id} удален." : $"Удаляемый объект с id = {id} не найден.");
    }

    /// <summary>
    /// Updates the product.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <returns>IActionResult.</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        var result = await _productRepository.UpdateAsync(product);
        return Ok(result ? $"Объект с id = {product.Id} обновлен." : $"Объект с id = {product.Id} не найден.");
    }
}