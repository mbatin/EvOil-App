using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace EvOil.Persistence;

public class EvOilDatabaseContextfactory : IDesignTimeDbContextFactory<EvOilDatabaseContext>
{
    public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
        {
            _ = builder.AddConsole();
        });

    public EvOilDatabaseContext CreateDbContext(string[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException("Connection string must be provided as argument!");
        }

        var connectionString = args[0];
        var optionsBuilder = new DbContextOptionsBuilder<EvOilDatabaseContext>();
        _ = optionsBuilder.UseSqlServer(connectionString);
        _ = optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory);

        var dbContext = new EvOilDatabaseContext(optionsBuilder.Options);

        return dbContext;
    }
}