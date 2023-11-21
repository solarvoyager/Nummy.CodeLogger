using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nummy.HttpLogger.Data.DataContext;
using Nummy.HttpLogger.Data.Services;
using Nummy.HttpLogger.Middleware;
using Nummy.HttpLogger.Models;
using Nummy.HttpLogger.Utils;

namespace Nummy.HttpLogger.Extensions;

public static class NummyCodeLoggerServiceExtension
{
    public static IServiceCollection AddNummyCodeLogger(this IServiceCollection services, Action<NummyCodeLoggerOptions> options)
    {
        var codeLoggerOptions = new NummyCodeLoggerOptions();
        options.Invoke(codeLoggerOptions);

        NummyModelValidator.ValidateNummyCodeLoggerOptions(codeLoggerOptions);

        services.Configure(options);

        services.AddDbContext<NummyCodeLoggerDataContext>(dbOptions =>
            dbOptions.UseNpgsql(codeLoggerOptions.DatabaseConnectionString));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<INummyCodeLoggerService, NummyHttpLoggerService>();

        // Automatically apply migrations during startup
        using var serviceScope = services.BuildServiceProvider().CreateScope();
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<NummyCodeLoggerDataContext>();

            // Ensure the database exists, and create it if not
            dbContext.Database.EnsureCreated();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                // Apply pending migrations
                // dbContext.Database.Migrate();
            }
        }

        return services;
    }
}