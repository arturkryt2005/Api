using Bakasov.Client.Services;

namespace Bakasov.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddHttpClient("Api", client =>
        {
            client.BaseAddress = new Uri("http://localhost:5057");
        });

        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddAntDesign();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}