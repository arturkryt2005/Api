using AntDesign;
using Bakasov.Client.Services;
using Bakasov.Core.Entities;
using Microsoft.AspNetCore.Components;

namespace Bakasov.Client.Components
{
    public partial class CreateForm
    {
        [Inject]
        private IProductService ProductService { get; set; } = null!;

        [Inject]
        private IMessageService MessageService { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        private Product _product = new();

        private bool IsLoading { get; set; }

        private async Task CreateAsync()
        {
            IsLoading = true;
            StateHasChanged();

            var response = await ProductService.CreateAsync(_product);

            if (response.IsSuccessStatusCode)
                await MessageService.Success("Товар успешно добавлен.");
            else
                await MessageService.Error(response.ReasonPhrase);

            NavigationManager.NavigateTo("/fetchdata", true);

            IsLoading = false;
            StateHasChanged();
        }
    }
}
