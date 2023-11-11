using AntDesign;
using Bakasov.Client.Services;
using Bakasov.Core.Entities;
using Microsoft.AspNetCore.Components;

namespace Bakasov.Client.Components
{
    public partial class EditForm
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IProductService ProductService { get; set; } = null!;

        [Inject]
        private IMessageService MessageService { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        private Product _product = new();

        protected override async Task OnInitializedAsync()
        {
            _product = (await ProductService.GetProductsAsync())?
                .FirstOrDefault(p => p.Id == Id)!;
        }

        private async Task EditAsync()
        {
            var response = await ProductService.UpdateAsync(_product);

            if (response.IsSuccessStatusCode)
                await MessageService.Success($"Товар {_product.Id} успешно обновлен.");
            else
                await MessageService.Error(response.ReasonPhrase);

            NavigationManager.NavigateTo("/fetchdata", true);
        }
    }
}
