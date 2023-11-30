using Bakasov.Core.Entities.Orders;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.Orders;

public interface IOrderRepository : IBaseRepository<Order>
{

}

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}