using Nummy.HttpLogger.Data.Entitites;
using Nummy.HttpLogger.Data.DataContext;

namespace Nummy.HttpLogger.Data.Services;

internal class NummyHttpLoggerService : INummyCodeLoggerService
{
    private readonly NummyCodeLoggerDataContext _nummyDataContext;

    public NummyHttpLoggerService(NummyCodeLoggerDataContext nummyDataContext)
    {
        _nummyDataContext = nummyDataContext;
    }

    public async Task LogRequestAsync(string requestBody, string requestPath, string remoteIpAddress, string httpLogGuid)
    {
        var data = new NummyCodeLog
        {
            HttpLogGuid = httpLogGuid,
            CreatedAt = DateTimeOffset.Now,
            DeletedAt = null,
            IsDeleted = false,
            Body = requestBody,
            Path = requestPath,
            RemoteIpAddress = remoteIpAddress
        };

        await _nummyDataContext.NummyRequestLogs.AddAsync(data);
        await _nummyDataContext.SaveChangesAsync();
    }

    public async Task LogResponseAsync(string responseBody, string httpLogGuid)
    {
        var data = new NummyResponseLog
        {
            HttpLogGuid = httpLogGuid,
            ResponseBody = responseBody
        };

        await _nummyDataContext.NummyResponseLogs.AddAsync(data);
        await _nummyDataContext.SaveChangesAsync();
    }
}