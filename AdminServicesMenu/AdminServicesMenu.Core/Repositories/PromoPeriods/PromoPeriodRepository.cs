using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.PromoPeriods;

public class PromoPeriodRepository(AdminServicesMenuDbContext dbContext) : IPromoPeriodRepository
{
    public IQueryable<PromoPeriod> GetAll() => 
        dbContext.PromoPeriods.AsQueryable();
    

    public Task AddAsync(PromoPeriod item, CancellationToken cancellationToken = default) => 
        dbContext.PromoPeriods.AddAsync(item, cancellationToken).AsTask();


    public Task AddAllAsync(IEnumerable<PromoPeriod> entities, CancellationToken cancellationToken = default) => 
        dbContext.PromoPeriods.AddRangeAsync(entities, cancellationToken);


    public Task UpdateAsync(PromoPeriod item, CancellationToken cancellationToken = default) =>
        dbContext.PromoPeriods
            .Where(p => p.Id == item.Id)
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(period => period.EndDate, item.EndDate)
                .SetProperty(period => period.StartDate, item.StartDate), cancellationToken);

    public Task DeleteAsync(PromoPeriod item, CancellationToken cancellationToken = default) =>
        dbContext.PromoPeriods
            .Where(p => p.Id == item.Id)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(IEnumerable<PromoPeriod> items, CancellationToken cancellationToken = default) =>
        dbContext.PromoPeriods
            .Intersect(items)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(Expression<Func<PromoPeriod, bool>> predicate, CancellationToken cancellationToken = default) =>
        dbContext.PromoPeriods
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
}