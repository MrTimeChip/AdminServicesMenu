using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories;

public abstract class EntityRepository<TEntity>(AdminServicesMenuDbContext dbContext) 
    : IRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> GetAll()
        => dbContext.Set<TEntity>().ToList().AsQueryable();

    public Task AddAsync(TEntity item, CancellationToken cancellationToken = default)
        => dbContext.Set<TEntity>().AddAsync(item, cancellationToken).AsTask();

    public Task AddAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        => dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

    public Task DeleteAllAsync(IEnumerable<TEntity> items, CancellationToken cancellationToken = default)
        => dbContext.Set<TEntity>()
            .Intersect(items)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => dbContext.Set<TEntity>()
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
    
    public abstract Task UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
    public abstract Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default);
}