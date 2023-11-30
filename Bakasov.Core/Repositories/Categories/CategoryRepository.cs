using Bakasov.Core.Entities.Categories;
using Bakasov.Core.Interfaces;
using Bakasov.Core.Repositories.Bases;

namespace Bakasov.Core.Repositories.Categories;

public interface ICategoryRepository : IBaseRepository<Category>
{

}

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IBakasovDbContext dbContext) : base(dbContext)
    {

    }
}