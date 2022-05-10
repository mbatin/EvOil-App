using EvOil.Domain.Models;
using Microsoft.EntityFrameworkCore;
using EvOil.Persistence.Configurations;
using EvOil.Business.Infrastructure;

namespace EvOil.Persistence;

public class EvOilDatabaseContext : DbContext, IEvOilDatabaseContext
{
    internal EvOilDatabaseContext(DbContextOptions<EvOilDatabaseContext> options) : base(options)
    {
    }

    public DbSet<Organizer> Organizers { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Oil> Oils { get; set; } = null!;

    public DbSet<Evaluation> Evaluations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfiguration(new OrganizerConfiguration());
        _ = modelBuilder.ApplyConfiguration(new UserConfiguration());
        _ = modelBuilder.ApplyConfiguration(new OilConfiguration());
        _ = modelBuilder.ApplyConfiguration(new EvaluationConfiguration());
    }
}
