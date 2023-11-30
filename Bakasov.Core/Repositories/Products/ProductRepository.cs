using Bakasov.Core.Entities.Products;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.Products;

public interface IProductRepository : IBaseRepository<Product>
{

}

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}