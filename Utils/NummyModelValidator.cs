using Nummy.CodeLogger.Models;

namespace Nummy.CodeLogger.Utils;

internal static class NummyModelValidator
{
    public static void ValidateNummyCodeLoggerOptions(NummyCodeLoggerOptions options)
    {
        if (string.IsNullOrEmpty(options.DatabaseConnectionString?.Trim()))
            throw new NummyCodeLoggerOptionsValidationException();
    }
}