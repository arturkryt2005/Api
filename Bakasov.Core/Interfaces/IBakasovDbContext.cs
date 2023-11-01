using Bakasov.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bakasov.Core.Interfaces;

/// <summary>
/// Interface IBakasovDbContext
/// </summary>
public interface IBakasovDbContext
{
    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    /// <value>The products.</value>
    DbSet<Product> Products { get; set; }
}