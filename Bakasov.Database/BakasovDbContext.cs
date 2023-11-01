using Bakasov.Core.Entities;
using Bakasov.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bakasov.Database;

public class BakasovDbContext : DbContext, IBakasovDbContext
{
    public BakasovDbContext(DbContextOptions<BakasovDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
}