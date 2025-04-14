using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories.PromoPeriods;

public class PromoPeriodRepository(AdminServicesMenuDbContext dbContext) 
    : EntityRepository<PromoPeriod>(dbContext), IPromoPeriodRepository
{
    private readonly AdminServicesMenuDbContext _dbContext = dbContext;
    
    public override Task UpdateAsync(PromoPeriod item, CancellationToken cancellationToken = default) 
        => _dbContext.PromoPeriods
            .Where(p => p.Id == item.Id)
            .ExecuteUpdateAsync(calls => calls
                .SetProperty(period => period.EndDate, item.EndDate)
                .SetProperty(period => period.StartDate, item.StartDate), cancellationToken);

    public override Task DeleteAsync(PromoPeriod item, CancellationToken cancellationToken = default) 
        => _dbContext.PromoPeriods
            .Where(p => p.Id == item.Id)
            .ExecuteDeleteAsync(cancellationToken);
}