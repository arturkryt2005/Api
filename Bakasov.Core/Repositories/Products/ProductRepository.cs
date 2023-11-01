using Bakasov.Core.Entities;
using Bakasov.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bakasov.Core.Repositories.Products;

/// <summary>
/// Interface IProductRepository
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Gets the products.
    /// </summary>
    /// <returns>Task&lt;List&lt;Product&gt;&gt;.</returns>
    Task<List<Product>> GetProductsAsync();

    /// <summary>
    /// Adds the product asynchronous.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <returns>Task.</returns>
    Task AddProductAsync(Product product);

    /// <summary>
    /// Deletes the product asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> DeleteProductAsync(int id);

    /// <summary>
    /// Updates the product asynchronous.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> UpdateProductAsync(Product product);
}

/// <summary>
/// Class ProductRepository.
/// Implements the <see cref="Bakasov.Core.Repositories.Products.IProductRepository" />
/// </summary>
/// <seealso cref="Bakasov.Core.Repositories.Products.IProductRepository" />
public class ProductRepository : IProductRepository
{
    /// <summary>
    /// The database context
    /// </summary>
    private readonly IBakasovDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository" /> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public ProductRepository(IBakasovDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get products as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;List`1&gt; representing the asynchronous operation.</returns>
    public async Task<List<Product>> GetProductsAsync()
    {
        var products = _dbContext.Products.ToList();
        return products;
    }

    /// <summary>
    /// Add product as an asynchronous operation.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public async Task AddProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await ((DbContext)_dbContext).SaveChangesAsync();
    }

    /// <summary>
    /// Delete product as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
    public async Task<bool> DeleteProductAsync(int id)
    {
        var deletedProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (deletedProduct != null)
        {
            _dbContext.Products.Remove(deletedProduct);
            await ((DbContext)_dbContext).SaveChangesAsync();
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// Update product as an asynchronous operation.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updatedProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

        if (updatedProduct != null)
        {
            _dbContext.Products.Update(product);
            await ((DbContext)_dbContext).SaveChangesAsync();
            return true;
        }
        else
            return false;
    }
}