using Bakasov.Core.Entities;
using Bakasov.Core.Entities.Brands;
using Bakasov.Core.Entities.Categories;
using Bakasov.Core.Entities.OrderProducts;
using Bakasov.Core.Entities.Orders;
using Bakasov.Core.Entities.Products;
using Bakasov.Core.Entities.Sizes;
using Bakasov.Core.Entities.Statuses;
using Bakasov.Core.Entities.Users;
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

    DbSet<Brand> Brands { get; set; }

    DbSet<Category> Categories { get; set; }

    DbSet<OrderProduct> OrderProducts { get; set; }

    DbSet<Order> Orders { get; set; }

    DbSet<Size> Sizes { get; set; }

    DbSet<Status> Statuss { get; set; }

    DbSet<User> Users { get; set; }
}