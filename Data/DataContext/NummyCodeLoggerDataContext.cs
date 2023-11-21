using Microsoft.EntityFrameworkCore;
using Nummy.HttpLogger.Data.Entitites;

namespace Nummy.HttpLogger.Data.DataContext;

internal class NummyCodeLoggerDataContext : DbContext
{
    public NummyCodeLoggerDataContext(DbContextOptions<NummyCodeLoggerDataContext> options) : base(options)
    {
    }

    public DbSet<NummyCodeLog> NummyCodeLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    // Define your DbSet properties here
    // Example:
    // public DbSet<User> Users { get; set; }
}