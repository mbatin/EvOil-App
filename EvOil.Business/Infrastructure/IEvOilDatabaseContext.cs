using EvOil.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EvOil.Business.Infrastructure;

public interface IEvOilDatabaseContext
{
    public DbSet<User> Users { get; }
    public DbSet<Oil> Oils { get; }
    public DbSet<Evaluation> Evaluations { get; }
    public DbSet<Organizer> Organizers { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}