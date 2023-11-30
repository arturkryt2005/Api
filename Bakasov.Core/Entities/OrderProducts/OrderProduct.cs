using Bakasov.Core.Entities.Orders;
using Bakasov.Core.Entities.Products;
using Bakasov.Core.Interfaces;

namespace Bakasov.Core.Entities.OrderProducts;

public class OrderProduct : IHaveId
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; }
}