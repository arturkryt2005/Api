using Bakasov.Core.Entities.Sizes;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.Sizes;

public interface ISizeRepository : IBaseRepository<Size>
{

}

public class SizeRepository : BaseRepository<Size>, ISizeRepository
{
    public SizeRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}