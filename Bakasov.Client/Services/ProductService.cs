using Bakasov.Core.Entities;

namespace Bakasov.Client.Services;

/// <summary>
/// Interface IProductService
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Gets the products asynchronous.
    /// </summary>
    /// <returns>Task&lt;List&lt;Product&gt;&gt;.</returns>
    Task<List<Product>> GetProductsAsync();
}

/// <summary>
/// Class ProductService.
/// Implements the <see cref="Bakasov.Client.Services.IProductService" />
/// </summary>
/// <seealso cref="Bakasov.Client.Services.IProductService" />
public class ProductService : IProductService
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Api");
    }

    /// <summary>
    /// Get products as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;List`1&gt; representing the asynchronous operation.</returns>
    public async Task<List<Product>> GetProductsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Product>>("api/Product");
        return response;
    }
}