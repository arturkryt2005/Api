
using Bakasov.Core.Interfaces;
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