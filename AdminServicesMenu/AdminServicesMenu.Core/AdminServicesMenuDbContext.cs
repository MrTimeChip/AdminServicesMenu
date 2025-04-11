using AdminServicesMenu.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminServicesMenu.Core;

public class AdminServicesMenuDbContext : DbContext
{
    public AdminServicesMenuDbContext(DbContextOptions<AdminServicesMenuDbContext> options)
        : base(options)
    {
    }

    public DbSet<PersonalSettings> PersonalSettings { get; set; }
    public DbSet<Preset> Presets { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<PromoPeriod> PromoPeriods { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PersonalSettings>()
            .HasKey(x => x.Id);

        builder.Entity<Preset>()
            .HasKey(x => x.Id);

        builder.Entity<PromoPeriod>()
            .HasKey(x => x.Id);

        builder.Entity<Service>()
            .HasKey(x => x.Id);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        optionsBuilder.UseInMemoryDatabase("AdminDb"); 
    } 
}