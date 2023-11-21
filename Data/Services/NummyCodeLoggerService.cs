using Nummy.CodeLogger.Data.DataContext;
using Nummy.CodeLogger.Data.Entitites;

namespace Nummy.CodeLogger.Data.Services;

internal class NummyCodeLoggerService : INummyCodeLoggerService
{
    private readonly NummyCodeLoggerDataContext _nummyDataContext;

    public NummyCodeLoggerService(NummyCodeLoggerDataContext nummyDataContext)
    {
        _nummyDataContext = nummyDataContext;
    }

    public async Task LogErrorAsync(string title, string? description = null)
    {
        await LogAsync(NummyCodeLogLevel.Error, title, description);
    }

    public async Task LogErrorAsync(Exception ex)
    {
        await LogAsync(NummyCodeLogLevel.Error, ex);
    }

    public async Task LogInfoAsync(string title, string? description = null)
    {
        await LogAsync(NummyCodeLogLevel.Info, title, description);
    }

    public async Task LogInfoAsync(Exception ex)
    {
        await LogAsync(NummyCodeLogLevel.Info, ex);
    }

    public async Task LogWarningAsync(string title, string? description = null)
    {
        await LogAsync(NummyCodeLogLevel.Warning, title, description);
    }

    public async Task LogWarningAsync(Exception ex)
    {
        await LogAsync(NummyCodeLogLevel.Warning, ex);
    }

    public async Task LogAsync(NummyCodeLogLevel logLevel, string title, string? description = null)
    {
        var data = new NummyCodeLog
        {
            LogGuid = Guid.NewGuid().ToString(),
            CreatedAt = DateTimeOffset.Now,
            LogLevel = logLevel,
            Title = title,
            Description = description
        };

        await InsertLogAsync(data);
    }

    public async Task LogAsync(NummyCodeLogLevel logLevel, Exception ex)
    {
        var data = new NummyCodeLog
        {
            LogGuid = Guid.NewGuid().ToString(),
            CreatedAt = DateTimeOffset.Now,
            LogLevel = logLevel,
            Title = ex.Message,
            StackTrace = ex.StackTrace,
            InnerException = ex.InnerException?.ToString(),
            ExceptionType = ex.GetType().FullName,
            Description = ex.ToString()
        };

        await InsertLogAsync(data);
    }

    private async Task InsertLogAsync(NummyCodeLog data)
    {
        await _nummyDataContext.NummyCodeLogs.AddAsync(data);
        await _nummyDataContext.SaveChangesAsync();
    }
}