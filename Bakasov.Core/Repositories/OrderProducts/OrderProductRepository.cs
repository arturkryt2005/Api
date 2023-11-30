using Bakasov.Core.Entities.OrderProducts;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.OrderProducts;

public interface IOrderProductRepository : IBaseRepository<OrderProduct>
{

}

public class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository
{
    public OrderProductRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}