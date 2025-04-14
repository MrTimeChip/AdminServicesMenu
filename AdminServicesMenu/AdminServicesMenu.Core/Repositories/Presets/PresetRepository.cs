using System.Linq.Expressions;
using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories;

public class PresetRepository(AdminServicesMenuDbContext dbContext) : IPresetRepository
{
    public IQueryable<Preset> GetAll() 
        => dbContext.Presets.ToList().AsQueryable();

    public Task AddAsync(Preset item, CancellationToken cancellationToken = default)
        => dbContext.Presets.AddAsync(item, cancellationToken).AsTask();

    public Task AddAllAsync(IEnumerable<Preset> entities, CancellationToken cancellationToken = default)
        => dbContext.Presets.AddRangeAsync(entities, cancellationToken);

    public Task UpdateAsync(Preset item, CancellationToken cancellationToken = default)
        => dbContext.Presets
            .Where(preset => preset.Id == item.Id)
            .ExecuteUpdateAsync(calls => 
                    calls.SetProperty(preset => preset.Favorites, item.Favorites), 
                cancellationToken);

    public Task DeleteAsync(Preset item, CancellationToken cancellationToken = default)
        => dbContext.Presets
            .Where(preset => preset.Id == item.Id)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(IEnumerable<Preset> items, CancellationToken cancellationToken = default) 
        => dbContext.Presets
            .Intersect(items)
            .ExecuteDeleteAsync(cancellationToken);

    public Task DeleteAllAsync(Expression<Func<Preset, bool>> predicate, CancellationToken cancellationToken = default) 
        => dbContext.Presets
            .Where(predicate)
            .ExecuteDeleteAsync(cancellationToken);
}