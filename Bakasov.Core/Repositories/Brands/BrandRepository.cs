using Bakasov.Core.Entities.Brands;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.Brands;

public interface IBrandRepository : IBaseRepository<Brand>
{

}

public class BrandRepository : BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}