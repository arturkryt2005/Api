using Bakasov.Core.Entities;
using Bakasov.Core.Entities.Brands;
using Bakasov.Core.Entities.Categories;
using Bakasov.Core.Entities.OrderProducts;
using Bakasov.Core.Entities.Orders;
using Bakasov.Core.Entities.Products;
using Bakasov.Core.Entities.Sizes;
using Bakasov.Core.Entities.Statuses;
using Bakasov.Core.Entities.Users;
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

    public DbSet<Brand> Brands { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Size> Sizes { get; set; }

    public DbSet<Status> Statuss { get; set; }

    public DbSet<User> Users { get; set; }
}