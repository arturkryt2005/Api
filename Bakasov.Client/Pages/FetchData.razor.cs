using AntDesign;
using Bakasov.Client.Services;
using Bakasov.Client.Shared;
using Bakasov.Core.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;

namespace Bakasov.Client.Pages;

/// <summary>
/// Class FetchData.
/// Implements the <see cref="Component" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class FetchData
{
    /// <summary>
    /// Gets or sets the product service.
    /// </summary>
    /// <value>The product service.</value>
    [Inject]
    private IProductService ProductService { get; set; } = null!;

    [Inject]
    private IMessageService MessageService { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    /// <summary>
    /// The table
    /// </summary>
    private ITable _table;

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    /// <value>The products.</value>
    private List<Product> Products { get; set; }

    /// <summary>
    /// The page index
    /// </summary>
    private int _pageIndex = 1;

    /// <summary>
    /// The page size
    /// </summary>
    private int _pageSize = 10;

    /// <summary>
    /// The total
    /// </summary>
    private const int _total = 0;

    /// <summary>
    /// The selected rows
    /// </summary>
    private IEnumerable<Product> _selectedRows;

    private bool IsLoading { get; set; }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        await FillTable();
    }

    private async Task FillTable() 
    {
        IsLoading = true;
        StateHasChanged();

        Products = await ProductService.GetProductsAsync();

        IsLoading = false;
        StateHasChanged();
    }

    private void OnChange()
    {

    }

    
    private async Task DeleteAsync(int id)
    {
        IsLoading = true;
        StateHasChanged();

        var response = await ProductService.DeleteAsync(id);

        if (response.IsSuccessStatusCode)
            await MessageService.Success("Товар успешно удален.");
        else
            await MessageService.Error(response.ReasonPhrase);

        IsLoading = false;
        StateHasChanged();

        await FillTable();

        StateHasChanged();
    }

    private async Task EditAsync(int id)
    {
        NavigationManager.NavigateTo($"/edit-form/{id}");
    }

    private void NavigateToCreateProduct()
    {
        NavigationManager.NavigateTo("/create-form");
    }
}