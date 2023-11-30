using Bakasov.Core.Entities.Users;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.Users;

public interface IUserRepository : IBaseRepository<User>
{

}

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}