using Bakasov.Core.Entities;
using Bakasov.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bakasov.Database;

/// <summary>
/// Class BakasovDbContext.
/// Implements the <see cref="DbContext" />
/// Implements the <see cref="IBakasovDbContext" />
/// </summary>
/// <seealso cref="DbContext" />
/// <seealso cref="IBakasovDbContext" />
public class BakasovDbContext : DbContext, IBakasovDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BakasovDbContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public BakasovDbContext(DbContextOptions<BakasovDbContext> options) : base(options)
    {

    }

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    /// <value>The products.</value>
    public DbSet<Product> Products { get; set; }
}