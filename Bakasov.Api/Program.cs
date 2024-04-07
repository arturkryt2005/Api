
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Brands;
using Bakasov.Core.Repositories.Categories;
using Bakasov.Core.Repositories.Orders;
using Bakasov.Core.Repositories.Products;
using Bakasov.Core.Repositories.Sizes;
using Bakasov.Core.Repositories.Statuses;
using Bakasov.Core.Repositories.Users;
using Bakasov.Database;
using Microsoft.EntityFrameworkCore;

namespace Bakasov.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region DBCONTEXT

        var connectionString = builder.Configuration["DbConnection"];

        builder.Services.AddDbContext<BakasovDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging();
        });

        builder.Services.AddScoped<IBakasovDbContext, BakasovDbContext>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IBrandRepository, BrandRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<ISizeRepository, SizeRepository>();
        builder.Services.AddScoped<IStatusRepository, StatusRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}