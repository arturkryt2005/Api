using Bakasov.Core.Entities.Statuses;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.Statuses;

public interface IStatusRepository : IBaseRepository<Status>
{

}

public class StatusRepository : BaseRepository<Status>, IStatusRepository
{
    public StatusRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}