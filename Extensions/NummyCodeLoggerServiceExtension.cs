using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nummy.CodeLogger.Data.DataContext;
using Nummy.CodeLogger.Data.Services;
using Nummy.CodeLogger.Models;
using Nummy.CodeLogger.Utils;

namespace Nummy.CodeLogger.Extensions;

public static class NummyCodeLoggerServiceExtension
{
    public static IServiceCollection AddNummyCodeLogger(this IServiceCollection services,
        Action<NummyCodeLoggerOptions> options)
    {
        var codeLoggerOptions = new NummyCodeLoggerOptions();
        options.Invoke(codeLoggerOptions);

        NummyModelValidator.ValidateNummyCodeLoggerOptions(codeLoggerOptions);

        services.Configure(options);

        services.AddDbContext<NummyCodeLoggerDataContext>(dbOptions =>
            dbOptions.UseNpgsql(codeLoggerOptions.DatabaseConnectionString));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<INummyCodeLoggerService, NummyCodeLoggerService>();

        // Automatically apply migrations during startup
        using var serviceScope = services.BuildServiceProvider().CreateScope();
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<NummyCodeLoggerDataContext>();

            // Ensure the database exists, and create it if not
            //dbContext.Database.EnsureCreated();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                // Apply pending migrations
                dbContext.Database.Migrate();
            }
        }

        return services;
    }
}