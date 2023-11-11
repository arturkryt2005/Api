using Bakasov.Core.Entities;
using Microsoft.AspNetCore.Mvc;

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

    Task<HttpResponseMessage> CreateAsync(Product product);

    Task<HttpResponseMessage> DeleteAsync(int id);

    Task<HttpResponseMessage> UpdateAsync(Product product);
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

    protected virtual string BasePath => typeof(Product).Name.ToLower();

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

    public async Task<HttpResponseMessage> CreateAsync(Product product)
    {
        var result = await _httpClient?.PostAsJsonAsync("api/Product"!, product)!;
        return result;
    }

    public async Task<HttpResponseMessage> DeleteAsync(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/Product/{id}");
        return result;
    }

    public async Task<HttpResponseMessage> UpdateAsync(Product product)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/Product", product);
        return result;
    }
}