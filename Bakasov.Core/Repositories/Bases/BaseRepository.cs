using Bakasov.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bakasov.Core.Repositories.Bases;

public interface IBaseRepository<TEntity>
{
    Task<List<TEntity>> GetListAsync();

    Task AddAsync(TEntity entity);

    Task<bool> DeleteAsync(int id);

    Task<bool> UpdateAsync(TEntity entity);
}

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IHaveId
{
    private readonly IBakasovDbContext _dbContext;

    protected BaseRepository(IBakasovDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<List<TEntity>> GetListAsync()
    {
        var products = ((DbContext)_dbContext)
            .Set<TEntity>()
            .ToList();
        return products;
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await ((DbContext)_dbContext)
            .Set<TEntity>()
            .AddAsync(entity);
        await ((DbContext)_dbContext).SaveChangesAsync();
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await ((DbContext)_dbContext)
            .Set<TEntity>()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (entity != null)
        {
            ((DbContext)_dbContext)
                .Set<TEntity>()
                .Remove(entity);
            await ((DbContext)_dbContext).SaveChangesAsync();
            return true;
        }
        else
            return false;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        if (entity != null)
        {
            ((DbContext)_dbContext)
                .Set<TEntity>()
                .Update(entity);
            await ((DbContext)_dbContext).SaveChangesAsync();
            return true;
        }
        else
            return false;
    }
}