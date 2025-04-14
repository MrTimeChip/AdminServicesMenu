using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core.Repositories;

public class PresetRepository(AdminServicesMenuDbContext dbContext) 
    : EntityRepository<Preset>(dbContext), IPresetRepository
{
    private readonly AdminServicesMenuDbContext _dbContext = dbContext;

    public override Task UpdateAsync(Preset item, CancellationToken cancellationToken = default)
        => _dbContext.Presets
            .Where(preset => preset.Id == item.Id)
            .ExecuteUpdateAsync(calls => 
                calls.SetProperty(preset => preset.Favorites, item.Favorites), cancellationToken);

    public override Task DeleteAsync(Preset item, CancellationToken cancellationToken = default)
        => _dbContext.Presets
            .Where(preset => preset.Id == item.Id)
            .ExecuteDeleteAsync(cancellationToken);
}